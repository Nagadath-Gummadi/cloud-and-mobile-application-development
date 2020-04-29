package com.example.hellotoast;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity {

    private int count=0;
    TextView show_text;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        show_text=(TextView)findViewById(R.id.show_toast);
    }
    public void show_count(View view) {
        Toast t=Toast.makeText(this ,"Hello", Toast.LENGTH_SHORT);
        t.show();
    }

    public void countUp(View view) {
        count++;
        show_text.setText(""+count);
    }
}






