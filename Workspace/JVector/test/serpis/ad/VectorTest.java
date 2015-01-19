package serpis.ad;

import static org.junit.Assert.*;

import org.junit.Test;

public class VectorTest {

	@Test
	public void testMin() {
		int vector[] = new int[] {33,16,12,15,19};
		int minValue = Vector.min(vector);
		
		assertEquals(12, minValue);
		
		assertEquals(7, Vector.min(new int[] {7,16,12,15,19}));
		assertEquals(1, Vector.min(new int[] {43,16,12,15,1}));
	}

	@Test(expected = ArrayIndexOutOfBoundsException.class)
	public void testMinEmpty(){
		Vector.min(new int[]{});
	}
}
