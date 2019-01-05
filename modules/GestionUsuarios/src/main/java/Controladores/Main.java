package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.awt.*;


public class Main {

    public final static Logger LOGGER = LogManager.getLogger("Controladores.Main");


    public static void main(String[] args) {
        System.setProperty("com.mchange.v2.log.FallbackMLog.DEFAULT_CUTOFF_LEVEL", "WARNING");
        System.setProperty("com.mchange.v2.log.MLog", "com.mchange.v2.log.FallbackMLog");

        EventQueue.invokeLater(() -> {
            try {
                Loggin logWindow = new Loggin();
                logWindow.getFrame().setVisible(true);

                Eventos.setLogginListenners(logWindow);

            } catch (Exception e) {
                e.printStackTrace();
            }
        });

    }



    public static void controlWindow(){

        EventQueue.invokeLater(() -> {
            try {
                ListadoUsuarios gestionWindow = new ListadoUsuarios();
                gestionWindow.getFrame().setVisible(true);

                Eventos.setListadoUsuariosListenners(gestionWindow);

            } catch (Exception e) {
                e.printStackTrace();
            }
        });
    }


}