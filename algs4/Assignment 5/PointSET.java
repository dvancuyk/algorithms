import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.RectHV;
import edu.princeton.cs.algs4.SET;
import edu.princeton.cs.algs4.StdDraw;

public class PointSET {

	private SET<Point2D> points;
	
	public PointSET() {
		points = new SET<Point2D>();
	}

	public boolean isEmpty() {
		return points.isEmpty();
	}

	public int size() {
		return points.size();
	}

	public void insert(Point2D p) {
		points.add(p);
	}

	public boolean contains(Point2D p) {
		return points.contains(p);
	}

	public void draw() {
		for(Point2D p : points) {
			StdDraw.filledCircle(p.x(), p.y(), .5);
		}
	}

	public Iterable<Point2D> range(RectHV rect) {
		return null;
	}

	public Point2D nearest(Point2D p) {
		return null;
	}

	public static void main(String[] args) {
	}
}
