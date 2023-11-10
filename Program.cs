using System.Diagnostics.Metrics;
using System;
using System.Reflection;

namespace SortingAgain
{
    internal class Program
    {
        public static void Main()
        {

            //создаем массив 
            int[] arr = new int[100];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 100);
            }
            // вывод исходного массива
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(" ");

            //вывод для сортировки выбором
            Console.WriteLine("Сортировка выбором");
            Console.WriteLine(string.Join(" ", SelectionSort(arr)));
            Console.Write(" ");

            // вывод результата всех сортировок

            //вывод для пирамидальной сортировки
            int n = arr.Length;

            HeapSort ob = new HeapSort();
            ob.heapSort(arr);

            Console.WriteLine("Пирамидальная сортировка");
            HeapSort.printArray(arr);
            

            //вывод для сортировки слиянием
            Console.WriteLine("Сортировка слиянием");
            Console.WriteLine(string.Join(" ", MergeSort.Sort(arr)));
            

            ////вывод для сортировки вставками
            Console.WriteLine("Сортировка вставками");
            Console.WriteLine(string.Join(" ", InsertionSort(arr)));
            

            //вывод для сортировки Методол Шелла
            Console.WriteLine("Сортировка Методом Шелла");
            Console.WriteLine(string.Join(" ", ShellSort(arr)));
            

            //вывод для пузырьковой сортировки 
            Console.WriteLine("Пузырькова сортировка");
            Console.WriteLine(string.Join(" ", BubbleSort(arr)));
            
        }



        //выбором - счетчики чек
        public static int[] SelectionSort(int[] arr)
        {
            int compareCounter = 0; // счетчик сравнений
            int assignmentCounter = 0; // счетчик присваиваний 

            int min, temp;
            int length = arr.Length;
            assignmentCounter++;

            for (int i = 0; i < length - 1; i++)
            {
                compareCounter++;
                min = i;
                assignmentCounter++;

                for (int j = i + 1; j < length; j++)
                {
                    compareCounter++;
                    if (arr[j] < arr[min])
                    {
                        compareCounter++;
                        min = j;
                        assignmentCounter++;
                    }
                }
                if (min != i)
                {
                    compareCounter++;
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                    assignmentCounter++;
                    assignmentCounter++;
                    assignmentCounter++;
                }
            }
            Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
            Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}");
            return arr;
        }
        
        //вставками - счетчики чек 
        public static int[] InsertionSort(int[] arr)
        {
            int compareCounter = 0; // счетчик сравнений
            int assignmentCounter = 0; // счетчик присваиваний 

            for (int i = 1; i < arr.Length; i++)
            {
                compareCounter++;
                int j;
                int buf = arr[i];
                assignmentCounter++;
                for (j = i - 1; j >= 0; j--)
                {
                    compareCounter++;
                    if (arr[j] < buf)
                    {
                        compareCounter++;
                        break;
                    }
                    arr[j + 1] = arr[j];
                    assignmentCounter++;
                }
                arr[j + 1] = buf;
                assignmentCounter++;
            }
            Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
            Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}");
            return arr;
        }

        //шелла - чек 
        public static int[] ShellSort(int[] arr)
        {
            int compareCounter = 0; // счетчик сравнений
            int assignmentCounter = 0; // счетчик присваиваний

            int step = arr.Length / 2;
            assignmentCounter++;
            while (step > 0)
            {
                compareCounter++;
                int i, j;
                for (i = step; i < arr.Length; i++)
                {
                    compareCounter++;
                    int value = arr[i];
                    for (j = i - step; (j >= 0) && (arr[j] > value); j -= step)
                    {
                        compareCounter++;
                        compareCounter++; // возможно это лишняя т.к. && и я не понимаю это одно сранение или два 
                        arr[j + step] = arr[j];
                        assignmentCounter++;
                    }
                    arr[j + step] = value;
                    assignmentCounter++;
                }
                step /= 2;
                assignmentCounter++;
            }
            Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
            Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}");
            return arr;
        }

        //пузырьковая - чек 
        public static int[] BubbleSort(int[] arr)
        {
            int compareCounter = 0; // счетчик сравнений
            int assignmentCounter = 0; // счетчик присваиваний 
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                compareCounter++;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    compareCounter++;
                    if (arr[j + 1] < arr[j])
                    {
                        compareCounter++;
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        assignmentCounter++;
                        assignmentCounter++;
                        assignmentCounter++;
                    }
                }
            }
            Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
            Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}"); // почему то выводит 0 непонимаю...
            return arr;
        }


        //быстрая - каюсь, это я нашла на просторах интернета 
        //счетчик чек
        public static void QuickSort(int[] arr, int start, int end)
        {

            int compareCounter = 0; // счетчик сравнений
            int assignmentCounter = 0; // счетчик присваиваний 

            int Partition(int[] arr, int start, int end)
            {
                int marker = start; // divides left and right subarrays
                assignmentCounter++;
                for (int i = start; i < end; i++)
                {
                    compareCounter++;
                    if (arr[i] < arr[end]) // array[end] is pivot
                    {
                        compareCounter++;
                        (arr[marker], arr[i]) = (arr[i], arr[marker]);
                        marker += 1;
                        assignmentCounter++;
                        assignmentCounter++;
                    }
                }
                // put pivot(array[end]) between left and right subarrays
                (arr[marker], arr[end]) = (arr[end], arr[marker]);
                assignmentCounter++;
                return marker;
            }

            if (start >= end)
            {
                compareCounter++;
                return;
            }    
                

            int pivot = Partition(arr, start, end);
            assignmentCounter++;
            QuickSort(arr, start, pivot - 1);
            assignmentCounter++;
            QuickSort(arr, pivot + 1, end);
            assignmentCounter++;

            Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
            Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}");
        }

        //пирамидальная - каюсь, это я нашла на просторах интернета 
        //мда надо всетаки переписать класс, ленивые счетчики не работают 
        public class HeapSort
        {
            public void heapSort(int[] arr)
            {
                int n = arr.Length;

                // Построение кучи (перегруппируем массив)
                for (int i = n / 2 - 1; i >= 0; i--)
                {
                    heapify(arr, n, i);
                }
                // Один за другим извлекаем элементы из кучи
                for (int i = n - 1; i >= 0; i--)
                {
                    // Перемещаем текущий корень в конец
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;

                    // вызываем процедуру heapify на уменьшенной куче
                    heapify(arr, i, 0);
                }
            }

            // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является индексом в arr[]. n - размер кучи
            void heapify(int[] arr, int n, int i)
            {
                int largest = i;
                // Инициализируем наибольший элемент как корень
                int l = 2 * i + 1; // left = 2*i + 1
                int r = 2 * i + 2; // right = 2*i + 2

                // Если левый дочерний элемент больше корня
                if (l < n && arr[l] > arr[largest])
                    largest = l;

                // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
                if (r < n && arr[r] > arr[largest])
                    largest = r;

                // Если самый большой элемент не корень
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;

                    // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                    heapify(arr, n, largest);
                }
            }

            // Вспомогательная функция для вывода на экран массива размера n 
            // удобнее держать ее внутри класса хотя логичнее было сделать ее общей 
            public static void printArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");
                Console.WriteLine("");
            }

        }


        //слиянием - каюсь, это я нашла на просторах интернета 
        //надо переделать под списки и тоже переписать класс
        public class MergeSort
        {
            public static int[] Sort(int[] arr)
            {
                if (arr.Length == 1)
                {
                    return arr;
                }

                int mid_point = arr.Length / 2;

                return Merge(Sort(arr.Take(mid_point).ToArray()), Sort(arr.Skip(mid_point).ToArray()));
            }

            public static int[] Merge(int[] arr1, int[] arr2)
            {
                int a = 0, b = 0;
                int[] merged = new int[arr1.Length + arr2.Length];

                for (int i = 0; i < arr1.Length + arr2.Length; i++)
                {
                    if (b < arr2.Length && a < arr1.Length)
                    {
                        if (arr1[a] > arr2[b] && b < arr2.Length)
                        {
                            merged[i] = arr2[b++];
                        }
                        else
                            merged[i] = arr1[a++];
                    }
                    else
                    {
                        if (b < arr2.Length)
                        {
                            merged[i] = arr2[b++];
                        }
                        else
                            merged[i] = arr1[a++];
                    }
                }
                return merged;
            }
        }



        //счетчик общий для всех - но метод для метода я писать не буду

        //int compareCounter = 0; // счетчик сравнений
        //int assignmentCounter = 0; // счетчик присваиваний 

        //assignmentCounter++;
        //compareCounter++;

        //Console.WriteLine($"Значения счетчика сравнений:{compareCounter}");
        //Console.WriteLine($"Значения счетчика присваиваний:{assignmentCounter}");
        //Console.WriteLine(" ");

    }
}


