package Controladores;

import Modelos.Tablas.Usuarios.Usuarios;
import org.apache.commons.codec.digest.DigestUtils;
import org.apache.logging.log4j.Level;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import java.util.ArrayList;
import java.util.List;

import static Controladores.Main.LOGGER;

public class UsuariosMannager {

    private static SessionFactory factory = null;
    private static UsuariosMannager manager;
    private static Usuarios loggedUser = null;

    public static UsuariosMannager getInstance(){

        if(factory == null){
            manager = new UsuariosMannager();
        }

        return manager;
    }

    private UsuariosMannager() {
        try {
            factory = new Configuration().configure().buildSessionFactory();
        } catch (Throwable ex) {
            System.err.println("Failed to create sessionFactory object." + ex);
            throw new ExceptionInInitializerError(ex);
        }
    }

    public boolean logIn(String username, String password){
        Session session = factory.openSession();

        Transaction trans = null;

        boolean logged = false;
        System.out.println("UserName: "+username);
        System.out.println("Password: "+password);

        System.out.println(DigestUtils.sha256Hex(password));

        try{
            trans = session.beginTransaction();
            List users = session.createQuery("FROM Usuarios WHERE nombre = '"+username+"' AND password = '"+password+"'").list();

            if (users.size()>0){
                loggedUser = (Usuarios) users.get(0);
                logged = true;
                LOGGER.info("Session Iniciada (Username: "+username+")");
            }else {
                LOGGER.info("Fallo de inicio de session. Usuario ("+username+") o contraseña invalidos");
            }

            trans.commit();

        }catch (HibernateException e) {
            if (trans!=null) trans.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return logged;
    }

    public boolean isLogged(){
        return loggedUser != null;
    }

    public ArrayList<Usuarios> getUsers(){

        ArrayList<Usuarios> usuarios = new ArrayList<Usuarios>();

        Session session = factory.openSession();
        Transaction trans = null;

        try{
            trans = session.beginTransaction();
            List ul = session.createQuery("FROM Usuarios WHERE role>1").list();

            for(Object obj : ul){
                Usuarios user = (Usuarios) obj;
                LOGGER.log(Level.INFO, user.getNombre()+" - "+user.getPassword());
                usuarios.add(user);
            }

            trans.commit();

        }catch (HibernateException e) {
            if (trans!=null) trans.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return usuarios;
    }

    public Usuarios getUser(int id){
        Session session = factory.openSession();
        Transaction trans = null;

        Usuarios user=null;

        try{
            trans = session.beginTransaction();
            user = (Usuarios) session.createQuery("FROM Usuarios WHERE id="+id).list().get(0);

            trans.commit();

        }catch (HibernateException e) {
            if (trans!=null) trans.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

        return user;
    }

    public String getRoleAsString(int role){
        switch (role){
            case 1: return "Admin";
            case 2: return "Moderador";
            case 3: return "Usuario";
        }
        return null;
    }
}
