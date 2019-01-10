package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import GUI.ModificarUsuario;
import GUI.NuevoUsuario;
import Modelos.Tablas.Usuarios.Usuarios;
import org.jetbrains.annotations.NotNull;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.util.Arrays;


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

            setModificarUsuariosListenners(mu);

            Usuarios user = UsuariosMannager.getInstance().getUser(Integer.parseInt(window.getTableUsuarios().getValueAt(window.getTableUsuarios().getSelectedRow(), 0).toString()));
            mu.setUser(user);
            mu.getTxtUsuario().setText(user.getNombre());
            mu.getComboRol().setSelectedIndex(user.getRole()-2);
            mu.getDialog().setVisible(true);

            mu.getDialog().addWindowListener(new WindowAdapter() {
                @Override
                public void windowClosed(WindowEvent e) {
                    refreshUsersTable(window);
                    super.windowClosed(e);
                }
            });
        });

        window.getBtnBorrar().addActionListener(e -> {

        });

        refreshUsersTable(window);
    }

    private static void refreshUsersTable(ListadoUsuarios window){

        new Thread(() -> {

            DefaultTableModel model = ((DefaultTableModel) window.getTableUsuarios().getModel());
            while (model.getRowCount()>0){
                model.removeRow(model.getRowCount()-1);
            }
            UsuariosMannager.getInstance().getUsers().forEach(user ->
                model.addRow(new Object[]{
                        user.getId(),
                        user.getNombre(),
                        UsuariosMannager.getInstance().getRoleAsString(user.getRole())
                }));
        }
        ).start();
    }

    public static void setModificarUsuariosListenners(ModificarUsuario window){

        window.getCbPassword().addActionListener(e -> {
            boolean status = window.getCbPassword().isSelected();
            window.getTxtPassword().setEnabled(status);
            window.getTxtPasswordRepeat().setEnabled(status);
        });


        window.getBtnModificar().addActionListener(e -> {
            if(!Arrays.equals(window.getTxtPassword().getPassword(), window.getTxtPasswordRepeat().getPassword())){
                System.out.println("Las contraseñas no coinciden");
                JOptionPane.showMessageDialog(null, "Las contraseñas no coinciden", "Error", JOptionPane.ERROR_MESSAGE);
                return;
            }
            UsuariosMannager.getInstance().updateUsuario(window.getUser());
            window.getDialog().dispose();
        });
    }


}
