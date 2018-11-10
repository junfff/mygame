package com.dudu.controller;

import java.util.List;

import com.dudu.service.testService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;


@RestController
public class testController {

    @Autowired
    private testService test;

    @RequestMapping("/index")
    public List login(@RequestParam("id") Integer id){


        return test.getList();
    }
}
