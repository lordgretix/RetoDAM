package Controladores;

import Modelos.Tablas.Usuarios.Usuarios;
import org.apache.commons.codec.digest.DigestUtils;
import org.apache.logging.log4j.Level;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import java.util.List;

public class UsuariosMannager {

    private static SessionFactory factory = null;
    private static UsuariosMannager manager;
    private static Usuarios loggedUser;

    public static UsuariosMannager createMannager(){

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

    public void listUsers(){
        Session session = factory.openSession();
        Transaction trans = null;

        try{
            trans = session.beginTransaction();
            List users = session.createQuery("FROM Usuarios WHERE nombre = 'prueba' AND password = 'papapa'").list();

            for(Object obj : users){
                Usuarios user = (Usuarios) obj;
                Main.LOGGER.log(Level.INFO, user.getNombre()+" - "+user.getPassword());
            }

            trans.commit();

        }catch (HibernateException e) {
            if (trans!=null) trans.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

    }
}
