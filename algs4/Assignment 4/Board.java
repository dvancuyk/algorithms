import java.util.Iterator;

import edu.princeton.cs.algs4.StdOut;

public class Board {
    private int[] board;
    private int n = 0;
    private int hammingScore = 0;
    private int manhattenScore = 0;
    private int blank = 0;
    private static int callCount = 0;
    
    // construct a board from an n-by-n array of blocks
    // (where blocks[i][j] = block in row i, column j)
    public Board(int[][] blocks) {
        board = new int[blocks.length * blocks.length + 1];
        n = blocks.length;

        int current = 1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                board[current] = blocks[i][j];

                if (board[current] == 0) {
                    blank = current; 
                }

                int manhatten = findManhattenScore(board[current], current, n);
                manhattenScore += manhatten;

                if (manhatten > 0) {
                    hammingScore++; 
                }

                current++;
            }
        }
    }

    private Board(Board source) {
        board = new int[source.board.length];
        for (int i = 1; i < source.board.length; i++) {
            board[i] = source.board[i];
        }

        hammingScore = source.hammingScore;
        manhattenScore = source.manhattenScore;
        n = source.n;
        blank = source.blank;
    }


    public int dimension() {
    	checkCount();
        return n;
    }

    public int hamming() {
    	checkCount();
        return hammingScore;
    }

    public int manhattan() {
    	checkCount();
        return manhattenScore;
    }

    public boolean isGoal() {
    	checkCount();
        return hammingScore + manhattenScore == 0;
    }

    public Board twin() {
    	checkCount();
        int x = 1;
        int y = this.board.length - 1;
        if (x == this.blank) 
        	x++;
        else if (y == this.blank)
        	y--;        
        
        return deviation(x, y);
    }

    public boolean equals(Object y) {
    	checkCount();
        if (y == this) return true;

        if (y == null) return false;

        if (y.getClass() != this.getClass()) return false;

        Board that = (Board) y;

        if (this.blank == that.blank && this.hammingScore != that.hammingScore 
                && this.manhattenScore != that.manhattenScore) {
            return false;
        }

        for (int i = 0; i < board.length; i++) {
            if (board[i] != that.board[i])
                return false;
        }

        return true;
    }

    public Iterable<Board> neighbors() {
    	checkCount();
        return new PathFinder(this);
    }

    private class PathFinder implements Iterable<Board> {
        private Board board;

        public PathFinder(Board board) {
            this.board = board;
        }

        public Iterator<Board> iterator() {

            return new Neighbors(board);
        }

    }

    private class Neighbors implements Iterator<Board> {
    	
        private int[] candidates;
        private int current = 0;
        private Board o;

        public Neighbors(Board origin) {
            o = origin;

            candidates = new int[] { o.blank - 1, o.blank - o.n, o.blank + 1, o.blank + o.n};
        }

        public boolean hasNext() {
            while (current < candidates.length && !isNeighbor(current)) {
                current++;   
            }

            return current < candidates.length;
        }

        public Board next() {
            if (!hasNext()) {
                throw new java.util.NoSuchElementException();
            }

            return o.deviation(o.blank, candidates[current++]);
        }

        public void remove() {
            throw new java.lang.UnsupportedOperationException();
        }

        private boolean isNeighbor(int current) {
            int value = candidates[current];
            boolean passes = value > 0 && value < o.board.length;

            // How do we determine if it is on the edge?
            if (passes && (value + 1 == o.blank || value - 1 == o.blank))
                passes = (o.blank - 1) / o.n == (candidates[current] - 1)/ o.n;

            return passes;
        }
    }

    public String toString() {
    	checkCount();
        StringBuilder converted = new StringBuilder();

        converted.append(n);
        converted.append(System.lineSeparator());
        String format = "%1$2s";
        
        if (n > 10) {
            format = "%1$3s";
        }
        
        for (int i = 0; i < n; i++) {
            for (int j = 1; j <= n; j++) {
//                if (i % n != 0)
//                    converted.append(" ");

                converted.append(String.format(format, board[n*i + j]) + " ");
            }                    

            converted.append(System.lineSeparator());
        }

        return converted.toString();
    }

    private Board deviation(int x, int y) {
        Board deviated = new Board(this);

        int current = findManhattenScore(board[x], x, n);
        int next = findManhattenScore(board[x], y, n);
        if (current > 0 && next == 0) {
            deviated.hammingScore--; 
        }
        else if (current == 0 && next > 0) {
            deviated.hammingScore++;
        }

        deviated.manhattenScore -= (current - next);

        current = findManhattenScore(board[y], y, n);
        next = findManhattenScore(board[y], x, n);
        if (current > 0 && next == 0) {
            deviated.hammingScore--; 
        }
        else if (current == 0 && next > 0) {
            deviated.hammingScore++;
        }

        deviated.manhattenScore -= (current - next);
        deviated.board[x] = board[y];
        deviated.board[y] = board[x];

        if (deviated.board[x] == 0)
            deviated.blank = x;
        if (deviated.board[y] == 0)
            deviated.blank = y;

        return deviated;
    }

    private static void checkCount() {
    	if (++callCount > 100000000) {
    		throw new java.lang.UnsupportedOperationException();
    	}  	
    }
    
    private static int findManhattenScore(int current, int expected, int size) {
        if (current == 0)
            return 0;

        int currentRow = (current - 1) / size;
        int currentColumn = (current - 1) % size;

        int expectedRow = (expected - 1) / size;
        int expectedColumn = (expected - 1) % size;

        // return rowDisplacement + columnDisplacement
        return abs(currentRow - expectedRow) + abs(currentColumn - expectedColumn);
    }

    private static int abs(int value) {
        if (value < 0) 
            return value * -1;

        return value;
    }

    public static void main(String[] args) {
        int[][] blocks = new int[3][3];
        blocks[0][0] = 1; 
        blocks[0][1] = 3; 
        blocks[0][2] = 5; 
        blocks[1][0] = 7; 
        blocks[1][1] = 2;
        blocks[1][2] = 6; 
        blocks[2][0] = 8; 
        blocks[2][1] = 0;
        blocks[2][2] = 4; 

        Board board = new Board(blocks);
        Board neighbor = board.neighbors().iterator().next();
        
        StdOut.println("Original");
        StdOut.println(board);
        StdOut.println("Neighbor");
        StdOut.println(neighbor);
        
        StdOut.println("All");
        for (Board n : neighbor.neighbors()) {
        		StdOut.println(n);
        	
        }
        StdOut.println("Neighbors");
        for (Board n : neighbor.neighbors()) {
        	if (!n.equals(board)) {
        		StdOut.println(n);
        	}
        }
        
        
    }

    private static void print(Board board) {
        StdOut.println("Hamming Priority: " + board.hamming());
        StdOut.println("Manhatten Priority: " + board.manhattan());
        StdOut.println("Board: ");
        StdOut.println(board);
    }

}
