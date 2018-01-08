import java.util.Comparator;
import java.util.Iterator;

import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.MinPQ;

// Immutable type
// To implement the A* algorithm, you must use MinPQ from algs4.jar for the priority queue(s).
// Corner cases.  The constructor should throw a java.lang.NullPointerException if passed a null argument.
public class Solver {

	private Node solution;

	public Solver(Board initial) {

		solution = new Node(initial);
		
		if (initial.isGoal()) {
			return;
		}

		Node twinned = new Node(initial.twin());
		
		if (twinned.board.isGoal())
			return;
		
		
		MinPQ<Node> candidates = new MinPQ<Node>(new Priority());
		MinPQ<Node> alterverse = new MinPQ<Node>(new Priority());
		
		do {
			
			solution = process(solution, candidates);
			twinned = process(twinned, alterverse);	
//			
//			StdOut.println("Current:");
//			StdOut.println(solution.board);
			
		} while(!(solution.board.isGoal() || twinned.board.isGoal()));
	}

	public boolean isSolvable() {
		return solution.board.isGoal();
	}           

	public int moves() {
		if (!isSolvable())
			return -1;
		
		return solution.steps;
	}           

	public Iterable<Board> solution() {
		if (!isSolvable())
			return null;
		
		return new Solution(solution);
	}      

	private static Node process(Node previous, MinPQ<Node> nodes) {
		for (Board neighbor : previous.board.neighbors()) 
		if(previous.parent == null || !neighbor.equals(previous.parent.board))
			nodes.insert(previous.next(neighbor));
		
		return nodes.delMin();
	}
	
	public static void main(String[] args) {       
		// create initial board from file
		for (int fi = 12; fi < 13; fi++) {
			String number = String.format("%02d", fi);
			String file = "D:\\Projects\\Classes\\Algorithms\\Assignment 4\\files\\puzzle3x3-" + number + ".txt";
			In in = new In(file);
			int n = in.readInt();
			int[][] blocks = new int[n][n];

			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					blocks[i][j] = in.readInt();

			Board initial = new Board(blocks);

			Solver solver = new Solver(initial);
			StdOut.println("Expected: " + fi + ", Actual: " + solver.moves());
		}
		
		
//		String file = "D:\\Projects\\Classes\\Algorithms\\Assignment 4\\files\\puzzle3x3-08.txt";
//		In in = new In(file);
//		int n = in.readInt();
//		int[][] blocks = new int[n][n];
//
//		for (int i = 0; i < n; i++)
//			for (int j = 0; j < n; j++)
//				blocks[i][j] = in.readInt();
//
//		Board initial = new Board(blocks);
//
//		Solver solver = new Solver(initial);
//
//		if (!solver.isSolvable())
//			StdOut.println("No solution possible");
//		else {
//			print(solver.solution());
//			
//			StdOut.println("Minimum number of moves = " + solver.moves());
//		}
	}
	
    
	private class Node {

		private Board board;
		private Node parent;
		private int steps = 0;
		private int priority = 0;
		public Node(Board board) {
			this.board = board;
			priority = board.manhattan() + board.hamming();
		}

		public int priority() {
			return priority;
		}

		public Node next(Board neighbor) {
			Node child = new Node(neighbor);
			child.parent = this;
			child.steps = this.steps + 1;

			return child;
		}
	}

	private class Priority implements Comparator<Node> {

		public int compare(Node x, Node y) {
			int priority = x.priority() - y.priority();
			
			if (priority != 0) return priority;
			
			return x.steps - y.steps;
		}
	}

	private class Solution implements Iterable<Board> {

		private Node solution;
		
		public Solution(Node puzzelPath) {
			this.solution = puzzelPath;
		}
		public Iterator<Board> iterator() {
			return new SolutionWalker(this.solution);
		}

	}

	private class SolutionWalker implements Iterator<Board> {

		private Board[] sequence;
		private int current;

		public SolutionWalker(Node puzzelPath) {
			sequence = new Board[puzzelPath.steps + 1];
			current = 0;

			Node processing = puzzelPath; 
			for (int i = puzzelPath.steps; i >= 0; i--) {
				sequence[i] = processing.board;

				processing = processing.parent;
			}
		}

		public boolean hasNext() {
			return current < sequence.length;
		}

		public Board next() {
			if (!hasNext()) {
				throw new java.util.NoSuchElementException();
			}

			return sequence[current++];
		}

		public void remove() {
			throw new java.lang.UnsupportedOperationException();
		}

	}
}
