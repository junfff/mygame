package com.dudu.domain;

public class bnUser {

    private long userId;
    private long userPhone;
    private String userName;
    private double hisMoney;


    public long getUserId() {
        return userId;
    }
    public long getUserPhone() {
        return userPhone;
    }
    public String getUserName() {
        return userName;
    }
    public double getHisMoney() {
        return hisMoney;
    }
    public void setUserId(long userId) {
        this.userId = userId;
    }
    public void setUserPhone(long userPhone) {
        this.userPhone = userPhone;
    }
    public void setUserName(String userName) {
        this.userName = userName;
    }
    public void setHisMoney(double hisMoney) {
        this.hisMoney = hisMoney;
    }

    @Override
    public String toString() {

        return "{userId:"+userId+",userPhone:"+userPhone+",userName:"+userName+",hisMoney:"+hisMoney+"}";
    }
}
