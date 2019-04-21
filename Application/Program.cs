using System;
using System.Linq;
using System.Text;
using SortLib;
using SortLib.Sort;
using SortLib.Search;
using SortLib.Collections;

namespace Application
{
    static class Program
    {

        private static void Menu()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("======= Executing test at " + DateTime.Now + " =========");
            Console.WriteLine("======= Choose the sort algorithm below:       ========");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("[A] - MergeSort");
            Console.WriteLine("[B] - HeapSort");
            Console.WriteLine("[C] - QuickSort");
            Console.WriteLine("[D] - BinaryTree");
            Console.WriteLine("[E] - HeapTree");
            Console.WriteLine("[F] - AVLtree");
            Console.WriteLine("[G] - Queue");
            Console.WriteLine("[H] - Stack");
            Console.WriteLine("[I] - List /*Not implemented yet.*/");
            Console.WriteLine("[Esc] - Close\n");
            var algorith = Console.ReadKey();

            //teste to-do read file and make input array
            string input = "9528 - 6388 - 6243 - 2687 - 9223 - 3213 - 2923 - 1159 - 3559 - 686 - 988 - 3787 - 9204 - 4876 - 8074 - 6232 - 9449 - 4838 - 562 - 8561 - 4189 - 1546 - 6743 - 3251 - 4809 - 1216 - 2928 - 6691 - 5514 - 8075 - 167 - 6314 - 1249 - 143 - 8105 - 5784 - 6152 - 8598 - 2957 - 4682 - 6923 - 1688 - 6289 - 582 - 1019 - 1097 - 5981 - 9603 - 5017 - 2990 - 2201 - 6080 - 3889 - 3534 - 8910 - 8955 - 9499 - 6693 - 3052 - 3373 - 6294 - 7327 - 9630 - 6983 - 2696 - 9370 - 323 - 4328 - 7150 - 9135 - 7213 - 9446 - 4610 - 4279 - 8805 - 3988 - 358 - 4920 - 5547 - 1676 - 1528 - 9956 - 6778 - 130 - 602 - 1126 - 5272 - 6042 - 3567 - 9137 - 1854 - 8402 - 4930 - 9793 - 1210 - 4836 - 9954 - 4005 - 7708 - 5880 - 8427 - 2129 - 5747 - 9674 - 2270 - 6418 - 922 - 5158 - 7481 - 5839 - 9480 - 1784 - 6176 - 2795 - 4875 - 7810 - 3021 - 6676 - 1961 - 1250 - 6866 - 1485 - 7740 - 5542 - 7780 - 1309 - 7703 - 759 - 5832 - 9463 - 2380 - 8387 - 6468 - 7605 - 9253 - 5623 - 2051 - 271 - 3616 - 3505 - 1541 - 4665 - 2956 - 3203 - 9116 - 8447 - 2911 - 9728 - 5543 - 8205 - 733 - 9030 - 9017 - 884 - 158 - 4766 - 3436 - 8329 - 3579 - 6312 - 245 - 6236 - 3386 - 7398 - 7090 - 3417 - 246 - 7916 - 485 - 5512 - 627 - 3665 - 7761 - 4824 - 4539 - 3351 - 4085 - 9090 - 2302 - 1711 - 2361 - 2991 - 3927 - 5142 - 7449 - 250 - 897 - 1232 - 2796 - 5893 - 320 - 3949 - 7250 - 2032 - 2936 - 5174 - 2877 - 3322 - 7020 - 8557 - 2417 - 9909 - 9739 - 8254 - 9581 - 7915 - 1736 - 1812 - 2188 - 5710 - 2556 - 6587 - 9172 - 6513 - 4972 - 4970 - 8223 - 4384 - 1520 - 6375 - 621 - 165 - 9071 - 7600 - 2389 - 5690 - 2469 - 4300 - 9789 - 7357 - 6073 - 1043 - 3377 - 4936 - 1098 - 5641 - 383 - 5875 - 9268 - 4011 - 4914 - 8509 - 5740 - 8865 - 5940 - 2100 - 7470 - 9379 - 1459 - 3241 - 5099 - 2624 - 4439 - 1833 - 3080 - 6443 - 2132 - 9053 - 3011 - 1727 - 5814 - 5796 - 5172 - 6353 - 3515 - 1206 - 5410 - 9536 - 2788 - 7484 - 9284 - 6753 - 8200 - 7554 - 1069 - 1377 - 4961 - 8008 - 3461 - 191 - 8270 - 2343 - 924 - 2045 - 4670 - 4185 - 5214 - 601 - 2638 - 4044 - 2073 - 809 - 1998 - 9152 - 6921 - 2055 - 4526 - 6041 - 3463 - 8385 - 2264 - 8298 - 5419 - 592 - 5521 - 2308 - 6373 - 1726 - 8069 - 7491 - 4340 - 2709 - 9919 - 1353 - 6226 - 9457 - 914 - 9541 - 7303 - 6147 - 687 - 7870 - 8859 - 2221 - 3667 - 1617 - 546 - 9076 - 9186 - 9981 - 4322 - 899 - 669 - 4679 - 2266 - 4614 - 481 - 3981 - 6344 - 7619 - 2095 - 1066 - 450 - 4197 - 623 - 9217 - 8345 - 2947 - 9114 - 3566 - 9659 - 1953 - 3806 - 5023 - 8871 - 1449 - 9854 - 1255 - 3645 - 9190 - 7177 - 5599 - 8375 - 9738 - 1571 - 3423 - 9021 - 5991 - 6739 - 1179 - 5773 - 1950 - 5120 - 7102 - 9892 - 6259 - 4519 - 5789 - 8503 - 1109 - 9160 - 8029 - 4151 - 955 - 6988 - 6993 - 6119 - 5408 - 2239 - 561 - 8861 - 6936 - 8161 - 2332 - 8949 - 920 - 2584 - 1967 - 5465 - 3215 - 5629 - 155 - 1430 - 2899 - 7803 - 9411 - 7418 - 5972 - 1832 - 4215 - 1732 - 9879 - 9067 - 457 - 5342 - 4796 - 8713 - 3893 - 542 - 7496 - 2328 - 5146 - 9136 - 7152 - 4486 - 8907 - 5168 - 1612 - 990 - 7241 - 6652 - 910 - 9078 - 1897 - 7789 - 4411 - 6060 - 9555 - 6808 - 4416 - 5954 - 9236 - 5371 - 6725 - 8809 - 5451 - 1113 - 5829 - 7234 - 6347 - 5394 - 314 - 6438 - 6675 - 4897 - 8877 - 1441 - 3749 - 9817 - 9701 - 1447 - 5209 - 8933 - 2359 - 9666 - 3028 - 216 - 3623 - 1165 - 1016 - 6181 - 9764 - 4475 - 398 - 2661 - 7164 - 710 - 2802 - 1322 - 6247 - 2109 - 2034 - 5783 - 938 - 680 - 4489 - 9214 - 9261 - 5979 - 8622 - 4031 - 3266 - 9118 - 9628 - 9079 - 7497 - 8562 - 8346 - 3414 - 1734 - 984 - 894 - 1136 - 8140 - 447 - 2718 - 3633 - 6638 - 1329 - 1725 - 2677 - 4714 - 1698 - 8280 - 1317 - 9459 - 6816 - 2627 - 5873 - 9305 - 5648 - 4135 - 2905 - 8277 - 3643 - 5496 - 948 - 7002 - 6606 - 5589 - 4319 - 3663 - 8498 - 8466 - 2206 - 2454 - 4098 - 7485 - 7119 - 4547 - 9451 - 102 - 6343 - 7391 - 8325 - 8755 - 3734 - 8397 - 3397 - 5818 - 6275 - 7771 - 7917 - 1899 - 3071 - 1477 - 778 - 1077 - 1636 - 5025 - 9822 - 5488 - 1705 - 9072 - 7466 - 3763 - 1675 - 1829 - 9184 - 4811 - 2917 - 3668 - 3809 - 471 - 4114 - 9326 - 1618 - 6171 - 6081 - 5717 - 9883 - 6559 - 4937 - 1067 - 8121 - 3345 - 218 - 9024 - 659 - 6113 - 8770 - 3328 - 9549 - 7007 - 5739 - 6246 - 2868 - 6446 - 3304 - 4738 - 8090 - 4871 - 7564 - 6328 - 1191 - 8087 - 964 - 298 - 4637 - 42 - 148 - 3551 - 3564 - 9341 - 7156 - 9420 - 8932 - 1839 - 9164 - 9755 - 2501 - 518 - 3577 - 3853 - 6748 - 5682 - 3932 - 9816 - 4550 - 8839 - 609 - 5644 - 9081 - 5688 - 1621 - 959 - 4800 - 580 - 8110 - 6947 - 2346 - 6493 - 5970 - 7898 - 2341 - 7514 - 1391 - 7350 - 2669 - 8502 - 774 - 8094 - 3847 - 4700 - 7709 - 341 - 4768 - 4570 - 4292 - 7176 - 768 - 3953 - 5287 - 7925 - 2009 - 1006 - 5164 - 5924 - 5271 - 8942 - 3027 - 7919 - 9795 - 3789 - 5889 - 5194 - 2881 - 2559 - 9788 - 6299 - 7193 - 4612 - 5746 - 1492 - 8088 - 62 - 4791 - 7689 - 9493 - 6658 - 4549 - 3374 - 291 - 9611 - 2671 - 1818 - 415 - 1873 - 1472 - 3015 - 5904 - 5433 - 4390 - 4797 - 9571 - 9044 - 4033 - 4971 - 698 - 7859 - 4211 - 374 - 3764 - 6930 - 4105 - 4392 - 1162 - 3671 - 6487 - 8297 - 9547 - 9022 - 3525 - 2466 - 1457 - 734 - 4429 - 2391 - 5415 - 8243 - 2912 - 5473 - 9479 - 912 - 3593 - 6272 - 8800 - 7359 - 6088 - 9525 - 2149 - 6029 - 2921 - 7269 - 7299 - 5166 - 5498 - 6861 - 3553 - 6043 - 5462 - 8220 - 3202 - 3192 - 855 - 7307 - 8015 - 7291 - 4712 - 8938 - 4732 - 255 - 3116 - 1569 - 3586 - 1983 - 1723 - 2220 - 379 - 4808 - 4230 - 1231 - 3746 - 8897 - 3983 - 3859 - 6394 - 9328 - 4254 - 8978 - 3024 - 2127 - 399 - 5438 - 4988 - 9760 - 1702 - 641 - 3256 - 3216 - 4762 - 5081 - 4705 - 7990 - 1589 - 5937 - 9908 - 3440 - 8651 - 2742 - 319 - 1527 - 4736 - 595 - 3281 - 1764 - 7682 - 5525 - 4498 - 811 - 1771 - 9951 - 9166 - 7690 - 3432 - 43 - 6922 - 2534 - 7103 - 5226 - 4939 - 144 - 5741 - 2951 - 9992 - 9900 - 4137 - 8694 - 8198 - 8490 - 6520 - 7897 - 2643 - 9988 - 9263 - 868 - 2342 - 91 - 8336 - 8649 - 2413 - 9339 - 4022 - 4909 - 950 - 2797 - 3916 - 9504 - 6052 - 456 - 5254 - 9311 - 8284 - 741 - 1622 - 7027 - 6729 - 7893 - 2778 - 3072 - 8316 - 4070 - 8118 - 1913 - 5131 - 7353 - 5420 - 5851 - 7523 - 726 - 7641 - 8815 - 9393 - 9757 - 5517 - 9412 - 6476 - 4771 - 8996 - 5650 - 4894 - 1851 - 362 - 9233 - 8961 - 2777 - 2927 - 1573 - 9791 - 787 - 7006 - 2924 - 5519 - 7797 - 7885 - 4193 - 9707 - 8176 - 9267 - 7968 - 2224 - 5760 - 9632 - 7529 - 5586 - 2932 - 8350 - 8902 - 2988 - 1277 - 3220 - 7985 - 7545 - 4388 - 4690 - 9111 - 9061 - 6066 - 6478 - 7140 - 747 - 3470 - 3561 - 2939 - 8055 - 411 - 2786 - 2520 - 9052 - 7644 - 2159 - 9783 - 9672 - 8505 - 6165 - 2455 - 9419 - 4287 - 1544 - 8608 - 5444 - 1372 - 3392 - 9614 - 4341 - 1127 - 4224 - 5715 - 1369 - 684 - 8036 - 6480 - 5887 - 6945 - 6590 - 9126 - 1826 - 4942 - 9884 - 8729 - 3214 - 2753 - 4238 - 8650 - 4514 - 1442 - 8439 - 1645 - 9121 - 5341 - 4101 - 8825 - 8538 - 4584 - 9158 - 2700 - 4295 - 7340 - 2760 - 4980 - 3092 - 1424 - 3709 - 6791 - 8691 - 9751 - 1739 - 6550 - 3786 - 6868 - 700 - 9083 - 3285 - 7962 - 6728 - 5007 - 8748 - 4284 - 4810 - 459".Trim();
            
            string[] inputStr = input.Split("-");
            int[] bigArray = inputStr.Select(int.Parse).ToArray();

            int[] smallArray = new int[] { 15, 18, 16, 14, 63, 12, 62, 58, 66, 26, 6, 65, 46, 11, 7 };
            string[] strArray = new string[] {"mamão","arroz","muito","simples","nada", "arara", "matriz" };
            switch (algorith.Key)
            {
                case ConsoleKey.A:
                    TestMergeSort(smallArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.B:
                    TestHeapSort(BuildNodeArray(smallArray));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.C:
                    TestQuickSort(bigArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.D:
                    TestBinaryTree(bigArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.E:
                    TestHeapTree(bigArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.F:
                    TestAVLTree(bigArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.G:
                    TestQueue(smallArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.H:
                    TestStack(smallArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.I:
                    TestList(smallArray);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Menu();

            Console.WriteLine("Press any key to finish.");
            Console.ReadKey();
        }
        
        private static Node[] BuildNodeArray(int[] myArray)
        {
            int index = 0;
            Node[] nodes = new Node[myArray.Length];
            Random value = new Random();

            foreach (int item in myArray)
            {
                nodes[index] = new Node(index, myArray[index].ToString(), (index * value.Next(1,100)).ToString(), null);
                index++;
            }
            return nodes;
        }
        #region DUMMY LAZY TEST
        private static void TestMergeSort(int[] myArray)
        {
            Console.WriteLine("\n====== STABILITY! Divide to conquer! ======" +
                          "\nTime complexity Ω(nLog n) and O(nLog n) - Space complexity O(n)" +
                          "\n\n======Steps:\n");
            MergeSort mergesort = new MergeSort();
            mergesort.Mergesort(myArray, 0, myArray.Length - 1);

            Console.WriteLine("Execution time: " + mergesort.MSlog);
        }

        private static void TestHeapSort(Node[] myArray)
        {
            Console.WriteLine("\n====== SURVIVOR! Transform in-place to conquer! Choice for real-time! ======" +
                          "\nComplexity Time O(nLog n) and Space O(n)" +
                          "\n\n======Steps:\n");
            HeapSort sort = new HeapSort();

            StringBuilder result = new StringBuilder("Sorted array by heapsort ");

            foreach (Node node in sort.Heapsort(myArray))
            {
                result.Append(node.Key + " ");
            }

            Console.WriteLine("Execution time: " + sort.HSlog + "\n" +result);   
        }

        private static void TestQuickSort(int[] myArray)
        {
            Console.WriteLine("\n====== ECONOMIC (space), but beware...time is money too! Divide to conquer! ======" +
                        "\nTime complexity Ω(nLog n) and O(n²) - Space complexity O(Log n)" +
                       "\n\n");
            QuickSort quicksort = new QuickSort();
            quicksort.Quicksort(myArray, 0, myArray.Length - 1);

            StringBuilder result = new StringBuilder();
            foreach (int item in myArray)
            {
                result.Append(item.ToString() + " ");
            }
            Console.WriteLine("Execution time: " + quicksort.QSlog + "\n" + result);
        }

        private static void TestBinaryTree<T>(T[] myArray)
        {
            Console.WriteLine("\n ======== B-I-N-A-R-Y-T-R-E-E ================== " +
                "\n====Time complexity: \n   * best O(Log n) \n   * worst O(n) " +
                       "\n   * binary tree O(log h), where 'h' is height and logn <= h <= n" +
                       "\n====Space complexity O(n)\n\nSteps:\n");
   
            BinaryTree tree = new BinaryTree();

            for (int i = 0; i < myArray.Length; i++)
            {
                object obj1 = myArray[i];
                object obj2 = i;
                tree.Insert(obj1, obj2);
            }

            //DUMMY TEST
            Node node = null;
            object objInt = "beterraba";
            if ((node = tree.Search(objInt)) != null)
                Console.WriteLine("The Value of " + objInt + " key: " + node.Value);
            else
                Console.WriteLine("It was not possible to find the " + objInt + " key in the dataset.");

            //NODE IS A LEAF
            objInt = 62; //"nada";// 
            if (tree.Remove(objInt))
                Console.WriteLine("key " + objInt + " was successfully removed.");
            else
                Console.WriteLine("key " + objInt + " was not found.");
            if ((node = tree.Search(objInt)) != null)
                Console.WriteLine("The Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("It was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");

            Console.WriteLine("Search time for " + objInt + ": "+ tree.BSLog + "\n");
            //NODE HAS 1 SUBTREE
            objInt = 14; //"arroz";// 
            if (tree.Remove(objInt))
                Console.WriteLine("key " + objInt + " was successfully removed.");
            else
                Console.WriteLine("key " + objInt + " was not found.");
            if ((node = tree.Search(objInt)) != null)
                Console.WriteLine("The Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("It was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");

            //NODE HAS 2 SUBTREE
            objInt = 18;// "muito";//
            if (tree.Remove(objInt))
                Console.WriteLine("key " + objInt + " was successfully removed.");
            else
                Console.WriteLine("key " + objInt + " was not found.");

            if ((node = tree.Search(objInt)) != null)
                Console.WriteLine("The Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("It was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");

            //NODE HAS 2 SUBTREE AND IS ROOT
            objInt = 15; //"mamão";// 
            if (tree.Remove(objInt))
                Console.WriteLine("key " + objInt + " was successfully removed.");
            else
                Console.WriteLine("key " + objInt + " was not found.");

            if ((node = tree.Search(objInt)) != null)
                Console.WriteLine("The Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("It was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");
            
            Console.WriteLine("\nIn Order:\n" + tree.InOrder());
            Console.WriteLine("\nPos Order:\n" + tree.PosOrder());
            Console.WriteLine("\nPre Order:\n" + tree.PreOrder());
        }

        private static void TestHeapTree(int[] myArray)
        {
            Console.WriteLine("\n======== H-E-A-P-T-R-E-E ==================" +
                "\n======== Complexity: Time O(n) Espace O(1)\nSteps:\n");

            StringBuilder result = new StringBuilder("Inserting keys ");

            HeapTree tree = new HeapTree(myArray.Length);
            Random rnd = new Random();

            for (int i = 0; i < myArray.Length; i++) {
                tree.Insert(myArray[i], rnd.Next(1, myArray.Length * 100));
                result.Append(myArray[i] + " ");
                Console.WriteLine("Insert time: " + tree.HeapLog.ToString());
            }

            result.Append("\nMy heap result: ");
            for (int i = 0; i < myArray.Length; i++)
            {
                result.Append(tree.Heap[i].Key + " ");
            }
            
            Console.WriteLine("\n" + result);

            Console.WriteLine("\nIn Order:\n" + tree.InOrder());
            Console.WriteLine("\nPos Order:\n"+ tree.PosOrder());
            Console.WriteLine("\nPre Order:\n"+ tree.PreOrder());

            result.Clear();
            for (int i = 0; i < myArray.Length; i++)
            {
                result.Append(tree.Remove().Key + " ");
            }
            Console.WriteLine("\nRemoved nodes:" + result + "\n");
        }

        private static void TestAVLTree<T>(T[] myArray)
        {
            AvlTree avl = new AvlTree();

            Console.WriteLine("\nBALANCED! Time O(log n) Space O(n)");

            for (int i = 0; i < myArray.Length; i++)
            {
                object obj1 = myArray[i];
                object obj2 = i;
                avl.Insert(obj1, obj2);
            }

            Console.WriteLine("\nIn Order:\n" + avl.InOrder());
            Console.WriteLine("\nPos Order:\n" + avl.PosOrder());
            Console.WriteLine("\nPre Order:\n" + avl.PreOrder());
            
            Node node = null;
            object objInt = 0;// "nada";
            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Key + " synonymous of " + objInt + ": " + node.Value + " index: " + node.Index);
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset.");

            objInt = 9992;//"nada";
            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Value);
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");

            Console.WriteLine("\nkey " + objInt + ": " +avl.AvlLog.ToString());

            //NODE IS A LEAF
            if (avl.Remove(objInt))
                Console.WriteLine("\nkey " + objInt + " was successfully removed.");
            else
                Console.WriteLine("\nkey " + objInt + " was not found.");
            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");
            
            //NODE HAS 1 SUBTREE
            objInt = 9204; //"arroz";// 
            if (avl.Remove(objInt))
                Console.WriteLine("\nkey " + objInt + " was successfully removed.");
            else
                Console.WriteLine("\nkey " + objInt + " was not found.");
            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");
            
            //NODE HAS 2 SUBTREE
            objInt = 18;// "muito";//
            if (avl.Remove(objInt))
                Console.WriteLine("\nkey " + objInt + " was successfully removed.");
            else
                Console.WriteLine("\nkey " + objInt + " was not found.");

            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");
            
            //NODE HAS 2 SUBTREE AND IS ROOT
            objInt = 15; //"mamão";// 
            if (avl.Remove(objInt))
                Console.WriteLine("\nkey " + objInt + " was successfully removed.");
            else
                Console.WriteLine("\nkey " + objInt + " was not found.");

            if ((node = avl.Search(objInt)) != null)
                Console.WriteLine("\nThe Value of " + objInt + " key: " + node.Value + " your remove has failed.");
            else
                Console.WriteLine("\nIt was not possible to find the " + objInt + " key in the dataset. Did you remove it?\n");
            
            Console.WriteLine("\nIn Order:\n" + avl.InOrder());
        }

        private static void TestQueue(int[] myArray)
        {
            Console.WriteLine("\n======== Q-U-E-U-E ==================" +
               "\n======== Complexity: Queue O(1) Dequeue O(1)\nSteps:\n");

            StringBuilder result = new StringBuilder("Inserting value ");
            StringBuilder aux = new StringBuilder();

            Queue<object> myQueue = new Queue<object>(myArray.Length);
            myQueue.Enqueue("String");
            myQueue.Enqueue(103);
            myQueue.Enqueue(DateTime.Now);
            myQueue.Enqueue(5547.90);

            aux.Append("Testing generic queue: ");
            for (int i = 0; i < myQueue.Lenght; i++)
            {
                aux.Append(myQueue.GetQueue()[i] + " ");
            }

            /* for (int i = 0; i < myArray.Length; i++)
             {
                 result.Append(myArray[i] + " ");
                 myQueue.Enqueue(myArray[i]);
                 aux.Append(myQueue.GetQueue()[i] + " ");
             }*/

            result.Append("\n\nQueued elements: " + aux);

            object element = myQueue.Dequeue();
            result.Append("\n\nElement removed: " + element.ToString());

            aux.Clear();
            for (int i = myQueue.GetStartIdx(); i <= myQueue.Lenght; i++)
            {
                aux.Append(myQueue.GetQueue()[i] + " ");
            }

            result.Append("\n\nCurrent queue: " + aux);
            Console.WriteLine(result);
        }

        private static void TestStack(int[] myArray)
        {
            Console.WriteLine("\n======== S-T-A-C-K ==================" +
               "\n======== Complexity: Push O(1) Pop O(1)\nSteps:\n");
            
            StringBuilder result = new StringBuilder();

            Stack<object> myStack = new Stack<object>();
            myStack.Push("String");
            myStack.Push(103);
            myStack.Push(DateTime.Now);
            myStack.Push(5547.90);

            result.Append("Testing generic stack: " + myStack.PrintStack());
             
            object element = myStack.Pop();
            result.Append("\n\nTop element removed: " + element.ToString());
            result.Append("\n\nCurrent stack: " + myStack.PrintStack() + " ");

            myStack.Push("Hello world!");
            result.Append("\n\nPushing: Hello world!");
            result.Append("\n\nCurrent stack: " + myStack.PrintStack() + " ");


            element = myStack.Pop();
            result.Append("\n\nTop element removed: " + element.ToString());
            result.Append("\n\nCurrent stack: " + myStack.PrintStack() + " ");

            Console.WriteLine(result);
        }

        private static void TestList(int[] myArray)
        {
            Console.WriteLine("\n======== L-I-S-T ==================" +
               "\n======== Complexity: Add O(1) Search/Remove O(n)\nSteps:\n");
            
            List<int> myList = new List<int>();
            for (int i = 0; i < myArray.Length; i++)
            {
                myList.Add(myArray[i]);
            }

            Console.WriteLine("List size: " + myList.Count + " Elements: " + myList.PrintList());

            myList.RemoveAt(3);
            Console.WriteLine("Remove at 3 index: " + myList.PrintList());

            myList.Remove(58);
            Console.WriteLine("Remove 58 element: " + myList.PrintList());


        }
        #endregion

    }
}
