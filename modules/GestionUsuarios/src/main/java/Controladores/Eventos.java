package Controladores;

import GUI.ListadoUsuarios;
import GUI.Loggin;
import GUI.ModificarUsuario;
import GUI.NuevoUsuario;
import org.jetbrains.annotations.NotNull;

import javax.swing.*;
import java.awt.*;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;


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

        window.getBtnBuscar().addActionListener(e -> {

        });

        window.getBtnAdd().addActionListener(e -> {

            NuevoUsuario nu = new NuevoUsuario(window.getFrame());
            nu.getDialog().setVisible(true);

        });

        window.getBtnModificar().addActionListener(e -> {
            ModificarUsuario mu = new ModificarUsuario(window.getFrame());
            mu.getTxtUsuario().setText("Pruebas");
            mu.getComboRol().setSelectedIndex(1);
            mu.getDialog().setVisible(true);
        });

        window.getBtnBorrar().addActionListener(e -> {

        });

    }

    static private ImageIcon rotateImageIcon(ImageIcon picture, double angle) {
        // FOR YOU ...
        int w = picture.getIconWidth();
        int h = picture.getIconHeight();
        int type = BufferedImage.TYPE_INT_ARGB;  // other options, see api
        BufferedImage image = new BufferedImage(h, w, type);
        Graphics2D g2 = image.createGraphics();
        double x = (h - w)/2.0;
        double y = (w - h)/2.0;
        AffineTransform at = AffineTransform.getTranslateInstance(x, y);
        at.rotate(Math.toRadians(angle), w/2.0, h/2.0);
        g2.drawImage(picture.getImage(), at, null);
        g2.dispose();
        picture = new ImageIcon(image);
        return picture;
    }

    private static ImageIcon rotateImage(Graphics g, double angle){

        Graphics2D g2 = (Graphics2D) g;
        g2.rotate(Math.toRadians(angle));
        //g2.drawImage()

        return null;
    }

}
