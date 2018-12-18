package Controlador;

import GUI.VentanaImportar;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.io.*;
import java.awt.EventQueue;

public class Main {

    private static VentanaImportar window;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    window = new VentanaImportar();
                    setListeners();
                    window.getFrame().setVisible(true);

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });

    }

    private static void setListeners(){

        window.getBtnAbrir().addActionListener(e->{
            JFileChooser fc = new JFileChooser();

            fc.setAcceptAllFileFilterUsed(false);
            fc.addChoosableFileFilter(new FileNameExtensionFilter("Extensible Markup Language (.xml)", "xml"));
            int result = fc.showOpenDialog(window.getFrame());

            if(result==JFileChooser.APPROVE_OPTION){
                window.getTxtInputDir().setText(fc.getSelectedFile().getPath());
            }
        });

        window.getBtnImportarDatos().addActionListener(e->{
            XMLReader reader = new XMLReader(window.getTxtInputDir().getText());
            reader.readAll();
        });
    }

    public static void limpiarXML(){
        try {
            FileReader fr = new FileReader("G:\\DAM2\\RetoDAM\\data\\alojamientos_rural_eus_copia.xml");
            BufferedReader bf = new BufferedReader(fr);
            FileWriter fw = new FileWriter("G:\\DAM2\\RetoDAM\\data\\alojamientos_rural_eus_copia_limpio.xml");
            BufferedWriter bw = new BufferedWriter(fw);
            String line;
            int i = 1;
            while((line= bf.readLine())!=null) {

                if(line.contains("row num=")) {
                    System.out.println(line.replaceAll("(\\d?\\d?\\d)", String.valueOf(i)));
                    bw.write(line.replaceAll("(\\d?\\d?\\d)", String.valueOf(i)));
                    bw.newLine();
                    i++;
                    continue;
                }
                bw.write(line);
                bw.newLine();

            }

            bw.close();
            fw.close();
            fr.close();
            bf.close();
        }catch (IOException e) {
            System.out.println(e.getMessage());
        }
    }
}
