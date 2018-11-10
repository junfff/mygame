package com.dudu.config;


import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

@Configuration
@ConfigurationProperties(prefix = "com.md")
@PropertySource("classpath:test.properties")
public class ConfigTestBean {
    private String name;
    private String want;


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


}