package com.dudu.service;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import com.dudu.domain.bnUser;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Service;


@Service
public class testService {

    @Autowired
    private JdbcTemplate jdbcTemplate;

    public List getList(){

        String sql = "select user_id,user_phone,user_name,his_money from bn_user";
        return (List) jdbcTemplate.query(sql, new RowMapper(){

            public bnUser mapRow(ResultSet rs, int rowNum) throws SQLException {
                bnUser bnUser = new bnUser();
                bnUser.setUserId(rs.getLong("user_id"));
                bnUser.setUserPhone(rs.getLong("user_phone"));
                bnUser.setUserName(rs.getString("user_name"));
                bnUser.setHisMoney(rs.getDouble("his_money"));

                return bnUser;
            }

        });
    }
}
