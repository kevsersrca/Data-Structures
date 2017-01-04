    class Sorting<T> where T :IComparable
    {

	//Yerdeğiştirme
        public void swap(ref T val1,ref T val2)
        {
            T temp = val1;
            val1 = val2;
            val2 = temp;
        }
	//public QuickSort method
        public void QuickSort(T[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            
        }
	//private QuickSort method
        private void QuickSort(T[] array, int l, int r)
        {
            if (l >= r)//tek parca oldugunda
                return;
            T pivot = array[l];
            int i = l ;
            int j = r;

            while (i < j)
            {
                while (i<r && array[i].CompareTo(pivot) != 1)//i'yi pivottan buyuk deger bulana kadar arttirir
                    i++;

                while (j>l && array[j].CompareTo(pivot) != -1)//j'yi pivottan kucuk bir deger bulana kadar azaltir
                    j--;
                swap(ref array[i], ref array[j]);
            }
            swap(ref array[i], ref array[j]);//en son yapılan gereksiz degistirmeyi duzeltme

            swap(ref array[l], ref array[j]);//pivotla j'yi yer degistir
            QuickSort(array,l,j-1);
            QuickSort(array, j + 1, r);
        }
	//Görüntüleme
        public void DisplayArray(T[] array)
        {
            foreach (T val in array)
            {
                Console.WriteLine(val);
            }
        }

    }

