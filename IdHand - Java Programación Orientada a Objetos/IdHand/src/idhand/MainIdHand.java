/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package idhand;

import java.util.ArrayList;

/**
 *
 * @author Usuario
 */
public class MainIdHand {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        Administrador admi = new Administrador();
        
        admi.setNombre("Wendy");
        admi.setCorreo("wendy@gmail.com");
        admi.setContraseña("12345");
        
        System.out.println("Nombre Administrador: " + admi.getNombre());
        System.out.println("Correo Administrador: " + admi.getCorreo());
        System.out.println("Contraseña Administrador: " + admi.getContraseña());

        Usuario usuario = new Usuario();
        
        usuario.setNombre("Daniela");
        usuario.setCorreo("danielavargas20-02@outlook.com");
        usuario.setContraseña("567890");
        usuario.setDocumento("1000756695");
        usuario.setRh("O+");
        usuario.setEps("Nueva EPS");
        usuario.setDireccion_CentroR("Cra. 46 # 47-66");
        usuario.setTelefono_CentroR("+5714193000");
        usuario.setArl("Sura");
        
        Usuario usuario2 = new Usuario();
        
        usuario2.setNombre("Gabriel");
        usuario2.setCorreo("gabriel@gmailcom");
        usuario2.setContraseña("876543");
        usuario2.setDocumento("100652765");
        usuario2.setRh("AB");
        usuario2.setEps("Sura");
        usuario2.setDireccion_CentroR("Calle 46C #42-65");
        usuario2.setTelefono_CentroR("+5715433456");
        usuario2.setArl("Sura");
        
        System.out.println("Nombre Usuario: " + usuario.getNombre());
        System.out.println("Correo Usuario: " + usuario.getCorreo());
        System.out.println("Contraseña Usuario: " + usuario.getContraseña());
        System.out.println("Documento del Usuario: " + usuario.getDocumento());
        System.out.println("RH: " + usuario.getRh());
        System.out.println("EPS: " + usuario.getEps());
        System.out.println("Dirreción de Centro de remisión: " + usuario.getDireccion_CentroR());
        System.out.println("Telefono del centro de remisión: " + usuario.getTelefono_CentroR());
        System.out.println("ARL: " + usuario.getArl());
        
        
        Persona persona = new Persona();
        
        persona.setId (1);
        persona.setCorreo ("primerintento@gmail.com");
        persona.setNombre ("Brayan Gonzalez");
        persona.setContraseña ("12345");
        
        System.out.println("Nombre: " + persona.getNombre());
        System.out.println("Contraseña: " + persona.getContraseña());
        
        
        Padecimiento pad = new Padecimiento();

        pad.setIdPadecimiento (1);
        pad.setTipo ("Alergia");
        pad.setNombre ("Ibuprofeno");
        
        Padecimiento pad2 = new Padecimiento();

        pad2.setIdPadecimiento (2);
        pad2.setTipo ("Enferemedad");
        pad2.setNombre ("gastritis");
        
        System.out.println("id Padecimiento: " + pad.getIdPadecimiento());
        System.out.println("tipo de padecimiento: " + pad.getTipo());
        System.out.println("nombre: " + pad.getNombre());
        
        
        Contacto co = new Contacto();

        co.setIdContacto (1);
        co.setCelular("313678900");
        co.setParentesco ("Madre");
        
        Contacto co2 = new Contacto();

        co2.setIdContacto (2);
        co2.setCelular("123456");
        co2.setParentesco ("Padre");
        
        System.out.println("id Contacto: " + co.getIdContacto());
        System.out.println("celular del Contacto: " + co.getCelular());
        System.out.println("parentesco: " + co.getParentesco());
        
        Usuario usu = new Usuario();
        ArrayList<Contacto> listaCont = new ArrayList();
        listaCont.add(co);
        listaCont.add(co2);
        usu.setListaContacto(listaCont);
        
        Contacto cont = new Contacto();
        ArrayList<Usuario> listaUsuario = new ArrayList();
        listaUsuario.add(usuario);
        listaUsuario.add(usuario2);
        cont.setListaUsuario(listaUsuario);
        
        Padecimiento pade = new Padecimiento();
        ArrayList<Usuario> listaUsuario2 = new ArrayList();
        listaUsuario.add(usuario);
        listaUsuario.add(usuario2);
        pade.setListaUsuario(listaUsuario2);
        
        Usuario usuar = new Usuario();
        ArrayList<Padecimiento> listaPade = new ArrayList();
        listaPade.add(pad2);
        listaPade.add(pade);
        usuar.setListaPadecimiento(listaPade);
        
    }

}
