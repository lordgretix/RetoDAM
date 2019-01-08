package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import GUI.ModificarUsuario;
import GUI.NuevoUsuario;
import Modelos.Tablas.Usuarios.Usuarios;
import org.jetbrains.annotations.NotNull;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;


public class Eventos {

    public static void setLogginListenners(@NotNull Loggin window){

        // Boton Login
        window.getBtnLogIn().addActionListener(e -> {

            window.getLblLoading().setVisible(true);

            // Log In
            new Thread(() -> {

                if (UsuariosMannager.getInstance().logIn(window.getTxtUsuario().getText(), String.valueOf(window.getTxtPassword().getPassword()))) {
                    Main.controlWindow();
                    window.getFrame().dispose();
                }else{
                    window.getLblLoading().setVisible(false);
                    JOptionPane.showMessageDialog(window.getFrame(), "Usuario o contraseña no validos", "Login Error", JOptionPane.ERROR_MESSAGE);
                }
            }).start();
        });
    }

    public static void setListadoUsuariosListenners(ListadoUsuarios window){


        window.getBtnBuscar().addActionListener(e -> {

        });

        window.getBtnAdd().addActionListener(e -> {

            NuevoUsuario nu = new NuevoUsuario(window.getFrame());
            nu.getDialog().setVisible(true);

        });

        window.getBtnModificar().addActionListener(e -> {
            ModificarUsuario mu = new ModificarUsuario(window.getFrame());

            Usuarios user = UsuariosMannager.getInstance().getUser(Integer.parseInt(window.getTableUsuarios().getValueAt(window.getTableUsuarios().getSelectedRow(), 0).toString()));
            mu.getTxtUsuario().setText(user.getNombre());
            mu.getComboRol().setSelectedIndex(user.getRole()-2);
            mu.getDialog().setVisible(true);
        });

        window.getBtnBorrar().addActionListener(e -> {

        });

        new Thread(() -> {
            UsuariosMannager.getInstance().getUsers().forEach(user ->
                    ((DefaultTableModel) window.getTableUsuarios().getModel()).addRow(new Object[]{
                            user.getId(),
                            user.getNombre(),
                            UsuariosMannager.getInstance().getRoleAsString(user.getRole())
            }));

        }).start();

    }


}
