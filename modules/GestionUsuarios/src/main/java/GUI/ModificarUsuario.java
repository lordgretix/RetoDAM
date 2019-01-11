/*
 * Created by JFormDesigner on Mon Jan 07 13:03:06 CET 2019
 */

package GUI;

import Modelos.Tablas.Usuarios.Usuarios;
import org.apache.commons.codec.digest.DigestUtils;

import java.awt.*;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import javax.swing.*;
import javax.swing.GroupLayout;

/**
 * @author taxpkhqr
 */
public class ModificarUsuario {

    private JFrame owner;
    private Usuarios user;
    private String oldPassword;
    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    // Generated using JFormDesigner Evaluation license - taxpkhqr
    private JDialog dialog;
    private JLabel lblUsuario;
    private JTextField txtUsuario;
    private JLabel lblPassword;
    private JPasswordField txtPassword;
    private JLabel lblPasswordRepeat;
    private JPasswordField txtPasswordRepeat;
    private JComboBox<String> comboRol;
    private JLabel lblRol;
    private JButton btnModificar;
    private JCheckBox cbPassword;
    // JFormDesigner - End of variables declaration  //GEN-END:variables

    public ModificarUsuario(JFrame owner) {
        this.owner = owner;
        initComponents();
    }

    private void initComponents() {

        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        // Generated using JFormDesigner Evaluation license - taxpkhqr
        dialog = new JDialog(owner);
        lblUsuario = new JLabel();
        txtUsuario = new JTextField();
        lblPassword = new JLabel();
        txtPassword = new JPasswordField();
        lblPasswordRepeat = new JLabel();
        txtPasswordRepeat = new JPasswordField();
        comboRol = new JComboBox<>();
        lblRol = new JLabel();
        btnModificar = new JButton();
        cbPassword = new JCheckBox();

        //======== dialog ========
        {
            dialog.setModalityType(Dialog.ModalityType.APPLICATION_MODAL);
            dialog.setTitle("Modificar Usuario");
            dialog.setResizable(false);
            Container dialogContentPane = dialog.getContentPane();

            //---- lblUsuario ----
            lblUsuario.setText("Nombre de Usuario");
            lblUsuario.setFont(new Font("Tahoma", Font.BOLD, 14));

            //---- txtUsuario ----
            txtUsuario.setFont(new Font("Tahoma", Font.PLAIN, 14));

            //---- lblPassword ----
            lblPassword.setText("Contrase\u00f1a");
            lblPassword.setFont(new Font("Tahoma", Font.BOLD, 14));

            //---- txtPassword ----
            txtPassword.setFont(new Font("Tahoma", Font.PLAIN, 14));
            txtPassword.setEnabled(false);
            txtPassword.addFocusListener(this.passwordPlaceholder());

            //---- lblPasswordRepeat ----
            lblPasswordRepeat.setText("Repetir Contrase\u00f1a");
            lblPasswordRepeat.setFont(new Font("Tahoma", Font.BOLD, 14));

            //---- txtPasswordRepeat ----
            txtPasswordRepeat.setFont(new Font("Tahoma", Font.PLAIN, 14));
            txtPasswordRepeat.setEnabled(false);
            txtPasswordRepeat.addFocusListener(this.passwordPlaceholder());

            //---- comboRol ----
            comboRol.setFont(new Font("Tahoma", Font.PLAIN, 14));
            comboRol.setModel(new DefaultComboBoxModel<>(new String[] {
                "Moderador",
                "Usuario"
            }));

            //---- lblRol ----
            lblRol.setText("Rol");
            lblRol.setFont(new Font("Tahoma", Font.BOLD, 14));

            //---- btnModificar ----
            btnModificar.setText("Modificar Usuario");
            btnModificar.setFont(new Font("Tahoma", Font.BOLD, 14));

            //---- cbPassword ----
            cbPassword.setText("Cambiar Contrase\u00f1a");
            cbPassword.setFont(new Font("Tahoma", Font.PLAIN, 14));

            GroupLayout dialogContentPaneLayout = new GroupLayout(dialogContentPane);
            dialogContentPane.setLayout(dialogContentPaneLayout);
            dialogContentPaneLayout.setHorizontalGroup(
                dialogContentPaneLayout.createParallelGroup()
                    .addGroup(dialogContentPaneLayout.createSequentialGroup()
                        .addGap(30, 30, 30)
                        .addGroup(dialogContentPaneLayout.createParallelGroup()
                            .addComponent(cbPassword)
                            .addComponent(lblUsuario)
                            .addComponent(txtUsuario, GroupLayout.PREFERRED_SIZE, 200, GroupLayout.PREFERRED_SIZE)
                            .addGroup(dialogContentPaneLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false)
                                .addComponent(comboRol)
                                .addComponent(lblRol)
                                .addComponent(lblPasswordRepeat)
                                .addComponent(txtPasswordRepeat)
                                .addComponent(lblPassword)
                                .addComponent(txtPassword, GroupLayout.PREFERRED_SIZE, 200, GroupLayout.PREFERRED_SIZE)
                                .addGroup(dialogContentPaneLayout.createSequentialGroup()
                                    .addGap(25, 25, 25)
                                    .addComponent(btnModificar, GroupLayout.PREFERRED_SIZE, 150, GroupLayout.PREFERRED_SIZE))))
                        .addContainerGap(30, Short.MAX_VALUE))
            );
            dialogContentPaneLayout.setVerticalGroup(
                dialogContentPaneLayout.createParallelGroup()
                    .addGroup(dialogContentPaneLayout.createSequentialGroup()
                        .addGap(20, 20, 20)
                        .addComponent(lblUsuario)
                        .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(txtUsuario, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
                        .addGap(18, 18, 18)
                        .addComponent(cbPassword)
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
                        .addComponent(btnModificar, GroupLayout.PREFERRED_SIZE, 30, GroupLayout.PREFERRED_SIZE)
                        .addContainerGap(25, Short.MAX_VALUE))
            );
            dialog.pack();
            dialog.setLocationRelativeTo(null);
        }
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }

    private void refreshUser(){
        this.user.setNombre(this.txtUsuario.getText());
        if(this.getCbPassword().isSelected()){
            this.user.setPassword(DigestUtils.sha256Hex(String.valueOf(this.getTxtPassword().getPassword())));
        }else{
            this.user.setPassword(this.oldPassword);
        }

        this.user.setRole(this.comboRol.getSelectedIndex()+2);
    }

    public JFrame getOwner() {
        return owner;
    }

    public void setOwner(JFrame owner) {
        this.owner = owner;
    }

    public Usuarios getUser() {
        refreshUser();
        return user;
    }

    public void setUser(Usuarios user) {
        this.user = user;
        this.oldPassword = user.getPassword();
    }

    public String getOldPassword() {
        return oldPassword;
    }

    public void setOldPassword(String oldPassword) {
        this.oldPassword = oldPassword;
    }

    public JDialog getDialog() {
        return dialog;
    }

    public void setDialog(JDialog dialog) {
        this.dialog = dialog;
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

    public JButton getBtnModificar() {
        return btnModificar;
    }

    public void setBtnModificar(JButton btnModificar) {
        this.btnModificar = btnModificar;
    }

    public JCheckBox getCbPassword() {
        return cbPassword;
    }

    public void setCbPassword(JCheckBox cbPassword) {
        this.cbPassword = cbPassword;
    }

    private FocusListener passwordPlaceholder(){

        return new FocusListener() {
            boolean hasChange = false;

            @Override
            public void focusGained(FocusEvent e) {
                System.out.println("FocusGained: "+hasChange);
                if(!hasChange){
                    ((JPasswordField) e.getComponent()).setText("");
                }
            }

            @Override
            public void focusLost(FocusEvent e) {
                System.out.println("FocusLost: "+hasChange);
                if(((JPasswordField)e.getComponent()).getPassword().length==0){
                    ((JPasswordField) e.getComponent()).setText("password");
                    e.getComponent().setForeground(Color.LIGHT_GRAY);
                }else{
                    hasChange = true;
                    e.getComponent().setForeground(Color.BLACK);
                }
            }
        };
    }
}
