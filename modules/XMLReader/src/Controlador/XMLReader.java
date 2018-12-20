package Controlador;

import Modelos.Tablas.Alojamientos;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.swing.*;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class XMLReader {

    private ArrayList<Alojamientos> alojamientos;
    private File file;

    public XMLReader(String file) {
        this.file = new File(file);
        this.alojamientos = new ArrayList<Alojamientos>();
    }

    public void readAll(){

        try {
            Document doc = DocumentBuilderFactory.newInstance().newDocumentBuilder().parse(file);
            doc.getDocumentElement().normalize();

            this.alojamientos = new ArrayList<Alojamientos>();

            String lang = doc.getElementsByTagName("rows").item(0).getAttributes().getNamedItem("lang").getTextContent();

            NodeList nodes = doc.getElementsByTagName("row");
            for(int i=0; i<nodes.getLength(); i++){
                Alojamientos aloj = new Alojamientos();
                aloj.setIdioma(lang);
                NodeList childrens = nodes.item(i).getChildNodes();

                for(int x=0; x<childrens.getLength(); x++){
                    this.insertAlojamiento(aloj, childrens.item(x).getNodeName(), childrens.item(x).getTextContent());
                }
                alojamientos.add(aloj);
            }
/*
            System.out.println(alojamientos.size());

            String sql = "SELECT * FROM `alojamientos` WHERE ";

            for (Alojamientos aloj : this.alojamientos) {
                sql += "firma = \""+ aloj.getFirma()+"\"";

                if(this.alojamientos.get(this.alojamientos.size()-1) != aloj){
                    sql += " OR ";
                }
            }
            sql += ";";
            System.out.println();
            System.out.println(sql);*/


        } catch (SAXException | ParserConfigurationException | IOException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void insertAlojamiento(Alojamientos aloj, String nodeName, String value){

        switch(nodeName){
            case "documentname": aloj.setNombre(value); break;
            case "turismdescription": if(aloj.getResumen().equals("")){ aloj.setResumen(value); } else{ aloj.setDescripcion(value); } break;
            case "locality": aloj.setLocalidad(value); break;
            case "phone": aloj.setTelefono(value.replaceAll("[\\s\\-]", "")); break;
            case "address": aloj.setDireccion(value); break;
            case "qualityassurance": aloj.setCertificado(Boolean.valueOf(value)); break;
            case "tourismemail": aloj.setEmail(value); break;
            case "web": aloj.setWeb(value); break;
            case "lodgingtype": aloj.setTipo(value); break;
            case "productclub": aloj.setClub(Boolean.valueOf(value)); break;
            case "autocaravana": aloj.setAutocarabana(Boolean.valueOf(value)); break;
            case "signatura": aloj.setFirma(value); break;
            case "store": aloj.setTienda(Boolean.valueOf(value)); break;
            case "capacity": aloj.setCapacidad(Integer.valueOf(value)); break;
            case "postalcode": aloj.setCodPostal(value); break;
            case "latitudelongitude": aloj.setLatlong(value); break;
            case "municipality": aloj.setMunicipio(value); break;
            case "territory": aloj.setTerritorio(value); break;
        }

    }

    public ArrayList<Alojamientos> getAlojamientos() {
        return alojamientos;
    }

    public File getFile() {
        return file;
    }

    public void setFile(String file) {
        this.file = new File(file);
    }
}
