package com.dudu;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.RequestMapping;

@RestController
public class UserController {

    //方案1
//    @Value("${com.dudu.name}")
//    private  String name;
//    @Value("${com.dudu.want}")
//    private  String want;
//
//    @RequestMapping("/")
//    public String hexo(){
//        return name+","+want;
//    }

//方案2
//    @Autowired
//    ConfigBean configBean;
//    @RequestMapping("/")
//    public String hexo(){
//        return configBean.getName()+configBean.getWant() +
//                configBean.getYearhopeBB() + configBean.getYearhope();
//    }

    //方案3
    @Autowired
    ConfigTestBean configBean;
        @RequestMapping("/")
    public String hexo(){
        return configBean.getName()+configBean.getWant();
    }
}