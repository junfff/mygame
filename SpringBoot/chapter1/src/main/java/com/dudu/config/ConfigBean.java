package com.dudu;


import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(prefix = "com.dudu")
public class ConfigBean {
    private String name;
    private String want;
    private String yearhopeBB;
    private String yearhope;
    // 省略getter和setter
    public String getName(){
        return this.name;
    }
    public void setName(String name){
        this.name = name;
    }

    public String getWant(){
        return this.want;
    }
    public void setWant(String name){
        this.want = name;
    }

    public String getYearhopeBB(){
        return this.yearhopeBB;
    }
    public void setYearhopeBB(String name){
        this.yearhopeBB = name;
    }

    public String getYearhope(){
        return this.yearhope;
    }
    public void setYearhope(String name){
        this.yearhope = name;
    }
}
