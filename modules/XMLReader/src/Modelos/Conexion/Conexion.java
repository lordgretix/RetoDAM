package Modelos.Conexion;

import Modelos.Tablas.Alojamientos;

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

public class Conexion {

    private Connection conexion;
    private String user = "root";
    private String password = "";
    private String database = "";
    private String host = "localhost";
    private String port = "3306";

    public Conexion() {
    }

    public Conexion(String user, String password, String database, String host, String port) {
        this.user = user;
        this.password = password;
        this.database = database;
        this.host = host;
        this.port = port;
    }

    public String getUser() {
        return user;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getDatabase() {
        return database;
    }

    public void setDatabase(String database) {
        this.database = database;
    }

    public String getHost() {
        return host;
    }

    public void setHost(String host) {
        this.host = host;
    }

    public String getPort() {
        return port;
    }

    public void setPort(String port) {
        this.port = port;
    }

    /**
     * @return the conexion
     */
    public Connection getConexion() {
        return conexion;
    }

    public void openConexion() throws SQLException {
        conexion = DriverManager.getConnection("jdbc:mysql://" + this.host + ":" + this.port + "/" + this.database + "?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC", this.user, this.password);
    }

    public void closeConexion() {
        try {
            conexion.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void insertAlojamiento(Alojamientos alojamiento) {

        try {
            PreparedStatement st = this.conexion.prepareStatement("INSERT INTO `alojamientos` " +
                    "(nombre, telefono, direccion, email, web, certificado, club, restaurante, tienda, autocaravana, capacidad, cod_postal, latlong, municipio, territorio, firma) " +
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ON DUPLICATE KEY UPDATE " +
                    "nombre = ?, telefono = ?, direccion = ?, email = ?, web = ?, certificado = ?, club = ?, restaurante = ?, tienda = ?, autocaravana = ?, capacidad = ?, cod_postal = ?, latlong = ?, municipio = ?, territorio = ?, firma = ?");

            int i = 1;
            int x = i + 16;

            //Nombre
            st.setString(i++, alojamiento.getNombre());
            st.setString(x++, alojamiento.getNombre());

            //Telefono
            st.setString(i++, alojamiento.getTelefono());
            st.setString(x++, alojamiento.getTelefono());

            //Dieccion
            st.setString(i++, alojamiento.getDireccion());
            st.setString(x++, alojamiento.getDireccion());

            //Email
            st.setString(i++, alojamiento.getEmail());
            st.setString(x++, alojamiento.getEmail());

            //Web
            st.setString(i++, alojamiento.getWeb());
            st.setString(x++, alojamiento.getWeb());

            //Certificado
            st.setBoolean(i++, alojamiento.isCertificado());
            st.setBoolean(x++, alojamiento.isCertificado());

            //Club
            st.setBoolean(i++, alojamiento.isClub());
            st.setBoolean(x++, alojamiento.isClub());

            //Restaurante
            st.setBoolean(i++, alojamiento.isRestaurante());
            st.setBoolean(x++, alojamiento.isRestaurante());

            //Tienda
            st.setBoolean(i++, alojamiento.isTienda());
            st.setBoolean(x++, alojamiento.isTienda());

            //Autocaravana
            st.setBoolean(i++, alojamiento.isAutocarabana());
            st.setBoolean(x++, alojamiento.isAutocarabana());

            //Capacidad
            st.setInt(i++, alojamiento.getCapacidad());
            st.setInt(x++, alojamiento.getCapacidad());

            //Codigo postal
            st.setString(i++, alojamiento.getCodPostal());
            st.setString(x++, alojamiento.getCodPostal());

            //Latitud y longitud
            st.setString(i++, alojamiento.getLatlong());
            st.setString(x++, alojamiento.getLatlong());

            //Municipio
            st.setString(i++, alojamiento.getMunicipio());
            st.setString(x++, alojamiento.getMunicipio());

            //Territorio
            st.setString(i++, alojamiento.getTerritorio());
            st.setString(x++, alojamiento.getTerritorio());

            //Firma
            st.setString(i++, alojamiento.getFirma());
            st.setString(x++, alojamiento.getFirma());

            st.execute();

        } catch (SQLException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, e.getMessage(), "Error: " + e.getErrorCode(), JOptionPane.ERROR_MESSAGE);
        }

    }

    public String[] getDepartamentos() {

        ArrayList<String> departamentos = new ArrayList<String>();
        try {
            ResultSet rs = conexion.prepareStatement("SELECT `dept_no`,`dnombre` FROM `departamentos`").executeQuery();

            while (rs.next()) {
                departamentos.add(rs.getString("dept_no") + "/" + rs.getString("dnombre"));
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

            while (rs.next()) {
                directores.add(rs.getString("emp_no") + "/" + rs.getString("apellido"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return directores.toArray(new String[directores.size()]);
    }

    public String[] getEmpleado(int emp_no) {

        ArrayList<String> empleado = new ArrayList<String>();
        try {
            ResultSet rs = conexion.prepareStatement("SELECT * FROM `empleados` WHERE `emp_no`=" + emp_no).executeQuery();

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
            JOptionPane.showMessageDialog(null, "No existe ningun empleado con ese numero", "Advertencia", JOptionPane.WARNING_MESSAGE);
        }

        return empleado.toArray(new String[empleado.size()]);
    }

    public void insertEmpleado(int emp_no, String apellido, String oficio, int dir, int dept_no, double salario, double comision) {

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

            JOptionPane.showMessageDialog(null, "Empleado insertado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);

        } catch (SQLException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, "Error: Ha ocurrido un fallo durante la insercion del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public void borrarEmpleado(int emp_no) {

        try {
            PreparedStatement st = conexion.prepareStatement("DELETE FROM `empleados` WHERE `emp_no`=?");
            st.setInt(1, emp_no);
            st.execute();
            JOptionPane.showMessageDialog(null, "Empleado borrado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);
        } catch (SQLException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, "Error: Ha ocurrido un fallo durante el borrado del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public void updateEmpleado(int emp_no, String apellido, String oficio, int dir, int dept_no, double salario, double comision) {

        try {
            PreparedStatement st = conexion.prepareStatement("UPDATE `empleados` SET `apellido` = ?, `oficio` = ?, `dir` = ?, `salario` = ?, `comision` = ?, `dept_no` = ? WHERE `empleados`.`emp_no` = ?");

            st.setString(1, apellido.toUpperCase());
            st.setString(2, oficio.toUpperCase());
            st.setInt(3, dir);
            st.setFloat(4, (float) salario);
            st.setFloat(5, (float) comision);
            st.setInt(6, dept_no);
            st.setInt(7, emp_no);

            if (st.executeUpdate() > 0) {
                JOptionPane.showMessageDialog(null, "Empleado actualizado correctamente!", "Success", JOptionPane.INFORMATION_MESSAGE);
            } else {
                JOptionPane.showMessageDialog(null, "No existe ningun empleado con ese numero", "Advertencia", JOptionPane.WARNING_MESSAGE);
            }


        } catch (SQLException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, "Error: Ha ocurrido un fallo durante la actualizacion del empleado!", "Error", JOptionPane.ERROR_MESSAGE);
        }
    }
}
