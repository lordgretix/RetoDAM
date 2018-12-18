package Modelos.Conexion;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import javax.swing.JOptionPane;

public class Conexion{

    private Connection conexion;
    private JOptionPane message = new JOptionPane();

    public Conexion(String user, String pass, String bbdd){
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/"+bbdd+"?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC",user, pass);
        } catch (ClassNotFoundException cn) {
            cn.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    /**
     * @return the conexion
     */
    public Connection getConexion() {
        return conexion;
    }

    public void closeConexion() {
        try {
            conexion.close();
        } catch (SQLException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public String[] getDepartamentos() {

        ArrayList<String> departamentos = new ArrayList<String>();
        try {
            ResultSet rs = conexion.prepareStatement("SELECT `dept_no`,`dnombre` FROM `departamentos`").executeQuery();

            while(rs.next()) {
                departamentos.add(rs.getString("dept_no")+"/"+rs.getString("dnombre"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return departamentos.toArray(new String[departamentos.size()]);
    }

    public String[] getDirectores() {

        ArrayList<String> directores = new ArrayList<String>();
        try {
            ResultSet rs = conexion.prepareStatement("SELECT `emp_no`, `apellido` FROM `empleados` WHERE `emp_no` IN (SELECT `dir` FROM `empleados`)").executeQuery();

            while(rs.next()) {
                directores.add(rs.getString("emp_no")+"/"+rs.getString("apellido"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return directores.toArray(new String[directores.size()]);
    }

    public String[] getEmpleado(int emp_no) {

        ArrayList<String> empleado = new ArrayList<String>();
        try {
            ResultSet rs = conexion.prepareStatement("SELECT * FROM `empleados` WHERE `emp_no`="+emp_no).executeQuery();

            rs.next();

            empleado.add(String.valueOf(rs.getInt("emp_no")));
            empleado.add(rs.getString("apellido"));
            empleado.add(rs.getString("oficio"));
            empleado.add(rs.getString("dir"));
            empleado.add(String.valueOf(rs.getFloat("salario")));
            empleado.add(String.valueOf(rs.getFloat("comision")));
            empleado.add(String.valueOf(rs.getInt("dept_no")));
        } catch (SQLException e) {
            e.printStackTrace();
            message.showMessageDialog (null, "No existe ningun empleado con ese numero", "Advertencia", JOptionPane.WARNING_MESSAGE);
        }

        return empleado.toArray(new String[empleado.size()]);
    }

    public void insertEmpleado(int emp_no, String apellido, String oficio, int dir, int dept_no, double salario, double comision){

        try {
            PreparedStatement st = conexion.prepareStatement("INSERT INTO `empleados` (`emp_no`, `apellido`, `oficio`, `dir`, `fecha_alt`, `salario`, `comision`, `dept_no`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
            DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
            Date date = new Date();

            st.setInt(1, emp_no);
            st.setString(2, apellido.toUpperCase());
            st.setString(3, oficio.toUpperCase());
            st.setInt(4, dir);
            st.setString(5, dateFormat.format(date));
            st.setFloat(6, (float) salario);
            st.setFloat(7, (float) comision);
            st.setInt(8, dept_no);

            st.execute();

            message.showMessageDialog (null, "Empleado insertado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);

        } catch (SQLException e) {
            e.printStackTrace();
            message.showMessageDialog (null, "Error: Ha ocurrido un fallo durante la insercion del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public void borrarEmpleado(int emp_no) {

        try {
            PreparedStatement st = conexion.prepareStatement("DELETE FROM `empleados` WHERE `emp_no`=?");
            st.setInt(1, emp_no);
            st.execute();
            message.showMessageDialog (null, "Empleado borrado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);
        } catch (SQLException e) {
            e.printStackTrace();
            message.showMessageDialog (null, "Error: Ha ocurrido un fallo durante el borrado del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public void updateEmpleado(int emp_no, String apellido, String oficio, int dir, int dept_no, double salario, double comision){

        try {
            PreparedStatement st = conexion.prepareStatement("UPDATE `empleados` SET `apellido` = ?, `oficio` = ?, `dir` = ?, `salario` = ?, `comision` = ?, `dept_no` = ? WHERE `empleados`.`emp_no` = ?");

            st.setString(1, apellido.toUpperCase());
            st.setString(2, oficio.toUpperCase());
            st.setInt(3, dir);
            st.setFloat(4, (float) salario);
            st.setFloat(5, (float) comision);
            st.setInt(6, dept_no);
            st.setInt(7, emp_no);

            if(st.executeUpdate()>0) {
                message.showMessageDialog (null, "Empleado actualizado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);
            }
            else {
                message.showMessageDialog (null, "No existe ningun empleado con ese numero", "Advertencia", JOptionPane.WARNING_MESSAGE);
            }


        } catch (SQLException e) {
            e.printStackTrace();
            message.showMessageDialog (null, "Error: Ha ocurrido un fallo durante la actualizacion del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }
}
