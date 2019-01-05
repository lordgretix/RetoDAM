package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import GUI.NuevoUsuario;
import org.jetbrains.annotations.NotNull;


public class Eventos {

    public static void setLogginListenners(@NotNull Loggin window){

        // Boton Login
        window.getBtnLogIn().addActionListener(e -> {

            window.getLblLoading().setVisible(true);

            // Log In
            new Thread(() -> {
                UsuariosMannager manager = UsuariosMannager.createMannager();

                if (manager.logIn(window.getTxtUsuario().getText(), String.valueOf(window.getTxtPassword().getPassword()))) {
                    Main.controlWindow();
                    window.getFrame().dispose();
                }else{
                    window.getLblLoading().setVisible(false);
                }
            }).start();
        });
    }

    public static void setListadoUsuariosListenners(ListadoUsuarios window){

        window.getBtnAdd().addActionListener(e -> {

            NuevoUsuario nu = new NuevoUsuario(window.getFrame());
            nu.getDialog().show();

        });

    }

}
