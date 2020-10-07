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
public class Usuario extends Persona{
    
    private String documento;
    private String rh;
    private String eps;
    private String direccion_CentroR;
    private String telefono_CentroR;
    private String arl;
    ArrayList<Contacto> listaContacto;
    ArrayList<Padecimiento> listaPadecimiento;
    
    public Usuario(){
        
    }

    public Usuario(String documento, String rh, String eps, String direccion_CentroR, String telefono_CentroR, String arl, ArrayList<Contacto> listaContacto, ArrayList<Padecimiento> listaPadecimiento) {
        this.documento = documento;
        this.rh = rh;
        this.eps = eps;
        this.direccion_CentroR = direccion_CentroR;
        this.telefono_CentroR = telefono_CentroR;
        this.arl = arl;
        this.listaContacto = listaContacto;
        this.listaPadecimiento = listaPadecimiento;
    }

    public Usuario(String documento, String rh, String eps, String direccion_CentroR, String telefono_CentroR, String arl, ArrayList<Contacto> listaContacto, ArrayList<Padecimiento> listaPadecimiento, int id, String correo, String nombre, String contraseña) {
        super(id, correo, nombre, contraseña);
        this.documento = documento;
        this.rh = rh;
        this.eps = eps;
        this.direccion_CentroR = direccion_CentroR;
        this.telefono_CentroR = telefono_CentroR;
        this.arl = arl;
        this.listaContacto = listaContacto;
        this.listaPadecimiento = listaPadecimiento;
    }

    public String getDocumento() {
        return documento;
    }

    public void setDocumento(String documento) {
        this.documento = documento;
    }

    public String getRh() {
        return rh;
    }

    public void setRh(String rh) {
        this.rh = rh;
    }

    public String getEps() {
        return eps;
    }

    public void setEps(String eps) {
        this.eps = eps;
    }

    public String getDireccion_CentroR() {
        return direccion_CentroR;
    }

    public void setDireccion_CentroR(String direccion_CentroR) {
        this.direccion_CentroR = direccion_CentroR;
    }

    public String getTelefono_CentroR() {
        return telefono_CentroR;
    }

    public void setTelefono_CentroR(String telefono_CentroR) {
        this.telefono_CentroR = telefono_CentroR;
    }

    public String getArl() {
        return arl;
    }

    public void setArl(String arl) {
        this.arl = arl;
    }

    public ArrayList<Contacto> getListaContacto() {
        return listaContacto;
    }

    public void setListaContacto(ArrayList<Contacto> listaContacto) {
        this.listaContacto = listaContacto;
    }

    public ArrayList<Padecimiento> getListaPadecimiento() {
        return listaPadecimiento;
    }

    public void setListaPadecimiento(ArrayList<Padecimiento> listaPadecimiento) {
        this.listaPadecimiento = listaPadecimiento;
    }

}
    
