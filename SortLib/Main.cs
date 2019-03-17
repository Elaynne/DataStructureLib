using System;

namespace SortLib
{
        public static void Main(String[] args)
        {

            string str = "";
            try
            {
                //ler o arquivo de input para ordenar
                BufferedReader in = new BufferedReader(new FileReader(args[0]));
                StringBuffer sb = new StringBuffer();
                while (in.ready()) {
                    sb.append(in.readLine() + "\n");
                }
                str = sb.toString();
        in.close();
            }
            catch (IOException e)
            {
                System.out.println(e.getMessage());
            }

            String lines[] = str.split("\n");
            int numero_carga = Integer.parseInt(lines[0]);

            EstruturaCodigo vet[] = new EstruturaCodigo[numero_carga];

            for (int i = 1; i <= numero_carga; i++)
            {
                vet[i - 1] = new EstruturaCodigo(lines[i]);
            }


            //cria o arquivo de saída
            File file = new File(args[1]);

            if (!file.exists())
            {
                try
                {
                    file.createNewFile();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
            else
            {
                try
                {
                    file.delete();
                    file.createNewFile();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }
            }
            FileWriter fw = null;
            try
            {
                fw = new FileWriter(file.getAbsoluteFile());
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }

            bw = new BufferedWriter(fw);

            EstruturaCodigo out[] = new EstruturaCodigo[numero_carga];
	MergeSort(vet, out,0, numero_carga-1);
	
	try {
		bw.close();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}

}
