package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import GUI.ModificarUsuario;
import GUI.NuevoUsuario;
import Modelos.Tablas.Usuarios.Usuarios;
import org.jetbrains.annotations.NotNull;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.event.*;
import java.util.Arrays;


public class Eventos {

    public static void setLogginListenners(@NotNull Loggin window){

        KeyAdapter enter = new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                if (e.getKeyCode()==KeyEvent.VK_ENTER){
                    window.getBtnLogIn().doClick();
                }
            }
        };
        window.getTxtUsuario().addKeyListener(enter);
        window.getTxtPassword().addKeyListener(enter);
        window.getBtnLogIn().addKeyListener(enter);
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

        WindowAdapter wAdapter = new WindowAdapter() {
            @Override
            public void windowClosed(WindowEvent e) {
                refreshUsersTable(window);
                super.windowClosed(e);
            }
        } ;


        window.getBtnBuscar().addActionListener(e -> {

        });

        window.getBtnAdd().addActionListener(e -> {

            NuevoUsuario nu = new NuevoUsuario(window.getFrame());
            setNuevoUsuarioListenners(nu);
            nu.getDialog().setVisible(true);


            nu.getDialog().addWindowListener(wAdapter);

        });

        window.getBtnModificar().addActionListener(e -> {
            ModificarUsuario mu = new ModificarUsuario(window.getFrame());

            setModificarUsuariosListenners(mu);

            Usuarios user = UsuariosMannager.getInstance().getUser(Integer.parseInt(window.getTableUsuarios().getValueAt(window.getTableUsuarios().getSelectedRow(), 0).toString()));
            mu.setUser(user);
            mu.getTxtUsuario().setText(user.getNombre());
            mu.getComboRol().setSelectedIndex(user.getRole()-2);
            mu.getDialog().setVisible(true);

            mu.getDialog().addWindowListener(wAdapter);
        });

        window.getBtnBorrar().addActionListener(e -> {

        });

        window.getTableUsuarios().addMouseListener(new MouseAdapter() {
            @Override
            public void mousePressed(MouseEvent e) {
                if(e.getClickCount()==2){
                    window.getBtnModificar().doClick();
                }
            }
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
            if(!isValidPassword(window.getTxtPassword().getPassword(), window.getTxtPasswordRepeat().getPassword())) return;
            UsuariosMannager.getInstance().updateUsuario(window.getUser());
            window.getDialog().dispose();
        });
    }

    public static void setNuevoUsuarioListenners(NuevoUsuario window){

        window.getBtnCrear().addActionListener(e -> {
            if(!isValidPassword(window.getTxtPassword().getPassword(), window.getTxtPasswordRepeat().getPassword())) return;
            UsuariosMannager.getInstance().createUsuario(window.getUser());
            window.getDialog().dispose();
        });

    }

    private static boolean isValidPassword(char[] password , char[] repeat){
        boolean valid;
        if(!(valid=Arrays.equals(password, repeat))){
            JOptionPane.showMessageDialog(null, "Las contraseñas no coinciden", "Error", JOptionPane.ERROR_MESSAGE);
        }
        return valid;
    }


}
