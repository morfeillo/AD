package serpis.ad;

public class Vector {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int v[] = {10,2,3,4,5,6,7,8,9,1};
		int minimo;
		minimo=min(v);
		
		System.out.println("minimo "+minimo);
	}
	
	public static int min(int[] v){
		int minimo=v[0];
		
//		for (int i=1; i< v.length;i++){
//
//			if(v[i]<minimo){
//				minimo=v[i];
//			}
//		}
		//for super resumido.
		for (int item : v){
			if (item < minimo){
				minimo=item;
			}
		}
		return minimo;
	}

}
