//package com.dudu.controller;
//
//import com.dudu.domain.Customer;
//import com.dudu.domain.User;
//import org.springframework.web.bind.annotation.PathVariable;
//import org.springframework.web.bind.annotation.RequestMapping;
//import org.springframework.web.bind.annotation.RequestMethod;
//import org.springframework.web.bind.annotation.RestController;
//
//import java.util.List;
//
//@RestController
//@RequestMapping(value="/users")
//public class MyRestController {
//    private User user;
//    private List<Customer> userCustomers;
//    @RequestMapping(value="/{user}", method= RequestMethod.GET)
//    public User getUser(@PathVariable Long user) {
//        return this.user;
//    }
//    @RequestMapping(value="/{user}/customers", method=RequestMethod.GET)
//    List<Customer> getUserCustomers(@PathVariable Long user) {
//       return this.userCustomers;
//    }
//    @RequestMapping(value="/{user}", method=RequestMethod.DELETE)
//    public User deleteUser(@PathVariable Long user) {
//        return this.user;
//    }
//}