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
public class Padecimiento {
    
    private int idPadecimiento;
    private String tipo;
    private String nombre;
    private ArrayList<Usuario> listaUsuario;
    
    public  Padecimiento(){
        
    }

    public Padecimiento(int idPadecimiento, String tipo, String nombre, ArrayList<Usuario> listaUsuario) {
        this.idPadecimiento = idPadecimiento;
        this.tipo = tipo;
        this.nombre = nombre;
        this.listaUsuario = listaUsuario;
    }

    public int getIdPadecimiento() {
        return idPadecimiento;
    }

    public void setIdPadecimiento(int idPadecimiento) {
        this.idPadecimiento = idPadecimiento;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public ArrayList<Usuario> getListaUsuario() {
        return listaUsuario;
    }

    public void setListaUsuario(ArrayList<Usuario> listaUsuario) {
        this.listaUsuario = listaUsuario;
    }

    
}
