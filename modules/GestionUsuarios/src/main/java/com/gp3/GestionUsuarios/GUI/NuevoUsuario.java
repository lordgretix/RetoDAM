package com.gp3.GestionUsuarios.GUI;

import com.gp3.GestionUsuarios.Modelos.GUI.JTextFieldLimit;
import com.gp3.GestionUsuarios.Modelos.Tablas.Usuarios.Usuarios;
import org.apache.commons.codec.digest.DigestUtils;

import java.awt.*;
import javax.swing.*;
import javax.swing.GroupLayout;


public class NuevoUsuario extends JDialog{

    private JFrame owner;
    private Usuarios user;

    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    // Generated using JFormDesigner Evaluation license - taxpkhqr
    private JLabel lblUsuario;
    private JTextField txtUsuario;
    private JLabel lblPassword;
    private JPasswordField txtPassword;
    private JLabel lblPasswordRepeat;
    private JPasswordField txtPasswordRepeat;
    private JComboBox<String> comboRol;
    private JLabel lblRol;
    private JButton btnCrear;
    // JFormDesigner - End of variables declaration  //GEN-END:variables

    public NuevoUsuario(JFrame owner) {
        this.owner = owner;
        this.user = new Usuarios();
        initComponents();
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        // Generated using JFormDesigner Evaluation license - taxpkhqr
        lblUsuario = new JLabel();
        txtUsuario = new JTextField();
        lblPassword = new JLabel();
        txtPassword = new JPasswordField();
        lblPasswordRepeat = new JLabel();
        txtPasswordRepeat = new JPasswordField();
        comboRol = new JComboBox<>();
        lblRol = new JLabel();
        btnCrear = new JButton();

        //======== this ========
        setModalityType(Dialog.ModalityType.APPLICATION_MODAL);
        setTitle("Nuevo Usuario");
        setResizable(false);
        Container contentPane = getContentPane();

        //---- lblUsuario ----
        lblUsuario.setText("Nombre de Usuario");
        lblUsuario.setFont(new Font("Tahoma", Font.BOLD, 14));

        //---- txtUsuario ----
        txtUsuario.setFont(new Font("Tahoma", Font.PLAIN, 14));
        txtUsuario.setDocument(new JTextFieldLimit(20));

        //---- lblPassword ----
        lblPassword.setText("Contrase\u00f1a");
        lblPassword.setFont(new Font("Tahoma", Font.BOLD, 14));

        //---- txtPassword ----
        txtPassword.setFont(new Font("Tahoma", Font.PLAIN, 14));

        //---- lblPasswordRepeat ----
        lblPasswordRepeat.setText("Repetir Contrase\u00f1a");
        lblPasswordRepeat.setFont(new Font("Tahoma", Font.BOLD, 14));

        //---- txtPasswordRepeat ----
        txtPasswordRepeat.setFont(new Font("Tahoma", Font.PLAIN, 14));

        //---- comboRol ----
        comboRol.setFont(new Font("Tahoma", Font.PLAIN, 14));
        comboRol.setModel(new DefaultComboBoxModel<>(new String[] {
            "Moderador",
            "Usuario"
        }));

        //---- lblRol ----
        lblRol.setText("Rol");
        lblRol.setFont(new Font("Tahoma", Font.BOLD, 14));

        //---- btnCrear ----
        btnCrear.setText("Crear Usuario");
        btnCrear.setFont(new Font("Tahoma", Font.BOLD, 14));

        GroupLayout contentPaneLayout = new GroupLayout(contentPane);
        contentPane.setLayout(contentPaneLayout);
        contentPaneLayout.setHorizontalGroup(
            contentPaneLayout.createParallelGroup()
                .addGroup(contentPaneLayout.createSequentialGroup()
                    .addGap(30, 30, 30)
                    .addGroup(contentPaneLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false)
                        .addComponent(comboRol)
                        .addComponent(lblRol)
                        .addComponent(lblPasswordRepeat)
                        .addComponent(txtPasswordRepeat)
                        .addComponent(lblPassword)
                        .addComponent(lblUsuario)
                        .addComponent(txtUsuario, GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE)
                        .addComponent(txtPassword)
                        .addGroup(contentPaneLayout.createSequentialGroup()
                            .addGap(25, 25, 25)
                            .addComponent(btnCrear, GroupLayout.PREFERRED_SIZE, 150, GroupLayout.PREFERRED_SIZE)))
                    .addGap(30, 30, 30))
        );
        contentPaneLayout.setVerticalGroup(
            contentPaneLayout.createParallelGroup()
                .addGroup(contentPaneLayout.createSequentialGroup()
                    .addGap(20, 20, 20)
                    .addComponent(lblUsuario)
                    .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                    .addComponent(txtUsuario, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
                    .addGap(18, 18, 18)
                    .addComponent(lblPassword)
                    .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                    .addComponent(txtPassword, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
                    .addGap(18, 18, 18)
                    .addComponent(lblPasswordRepeat)
                    .addGap(6, 6, 6)
                    .addComponent(txtPasswordRepeat, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
                    .addGap(18, 18, 18)
                    .addComponent(lblRol)
                    .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                    .addComponent(comboRol, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
                    .addGap(18, 18, 18)
                    .addComponent(btnCrear, GroupLayout.PREFERRED_SIZE, 30, GroupLayout.PREFERRED_SIZE)
                    .addContainerGap(25, Short.MAX_VALUE))
        );
        pack();
        setLocationRelativeTo(null);
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    private void refreshUser(){
        this.user.setNombre(this.txtUsuario.getText());
        this.user.setPassword(DigestUtils.sha256Hex(String.valueOf(this.getTxtPassword().getPassword())));
        this.user.setRole(this.comboRol.getSelectedIndex()+2);
    }

    public Window getOwner() {
        return owner;
    }

    public void setOwner(JFrame owner) {
        this.owner = owner;
    }

    public JLabel getLblUsuario() {
        return lblUsuario;
    }

    public void setLblUsuario(JLabel lblUsuario) {
        this.lblUsuario = lblUsuario;
    }

    public JTextField getTxtUsuario() {
        return txtUsuario;
    }

    public void setTxtUsuario(JTextField txtUsuario) {
        this.txtUsuario = txtUsuario;
    }

    public JLabel getLblPassword() {
        return lblPassword;
    }

    public void setLblPassword(JLabel lblPassword) {
        this.lblPassword = lblPassword;
    }

    public JPasswordField getTxtPassword() {
        return txtPassword;
    }

    public void setTxtPassword(JPasswordField txtPassword) {
        this.txtPassword = txtPassword;
    }

    public JLabel getLblPasswordRepeat() {
        return lblPasswordRepeat;
    }

    public void setLblPasswordRepeat(JLabel lblPasswordRepeat) {
        this.lblPasswordRepeat = lblPasswordRepeat;
    }

    public JPasswordField getTxtPasswordRepeat() {
        return txtPasswordRepeat;
    }

    public void setTxtPasswordRepeat(JPasswordField txtPasswordRepeat) {
        this.txtPasswordRepeat = txtPasswordRepeat;
    }

    public JComboBox<String> getComboRol() {
        return comboRol;
    }

    public void setComboRol(JComboBox<String> comboRol) {
        this.comboRol = comboRol;
    }

    public JLabel getLblRol() {
        return lblRol;
    }

    public void setLblRol(JLabel lblRol) {
        this.lblRol = lblRol;
    }

    public JButton getBtnCrear() {
        return btnCrear;
    }

    public void setBtnCrear(JButton btnCrear) {
        this.btnCrear = btnCrear;
    }

    public Usuarios getUser() {
        refreshUser();
        return user;
    }

    public void setUser(Usuarios user) {
        this.user = user;
    }

}
