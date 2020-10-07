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
public class Contacto {
    
    private int idContacto;
    private String parentesco;
    private String celular ;
    private ArrayList<Usuario> listaUsuario;
    
    public Contacto(){
        
    }

    public Contacto(int idContacto, String parentesco, String celular, ArrayList<Usuario> ListaUsuario) {
        this.idContacto = idContacto;
        this.parentesco = parentesco;
        this.celular = celular;
        this.listaUsuario = ListaUsuario;
    }

    public ArrayList<Usuario> getListaUsuario() {
        return listaUsuario;
    }

    public void setListaUsuario(ArrayList<Usuario> ListaUsuario) {
        this.listaUsuario = ListaUsuario;
    }

    public int getIdContacto() {
        return idContacto;
    }

    public void setIdContacto(int idContacto) {
        this.idContacto = idContacto;
    }

    public String getParentesco() {
        return parentesco;
    }

    public void setParentesco(String parentesco) {
        this.parentesco = parentesco;
    }

    public String getCelular() {
        return celular;
    }

    public void setCelular(String celular) {
        this.celular = celular;
    }
    
    
    
}
