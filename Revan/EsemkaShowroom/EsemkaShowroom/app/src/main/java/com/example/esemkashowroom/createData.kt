package com.example.esemkashowroom

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.EditText
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.widget.AppCompatButton
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class createData : AppCompatActivity() {
  //  @SuppressLint("WrongViewCast")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create_data)

        findViewById<AppCompatButton>(R.id.c_create).setOnClickListener {
            val nama = findViewById<EditText>(R.id.c_nama).text.toString()
            val model = findViewById<EditText>(R.id.c_model).text.toString()
            val brand = findViewById<EditText>(R.id.c_brand).text.toString()
            val tahun = findViewById<EditText>(R.id.c_tahun).text.toString()
            val radio = findViewById<RadioGroup>(R.id.Group)
            val Forsale = when (radio.checkedRadioButtonId){
                R.id.yes -> true
                R.id.no -> false
                else -> false
            }

            GlobalScope.launch(Dispatchers.IO){
                val url = URL("https://6597231a668d248edf22a0d3.mockapi.io/Cars")
                val conn = url.openConnection() as HttpURLConnection
                conn.requestMethod = "POST"
                conn.doOutput = true
                conn.setRequestProperty("Content-Type","application/json")


                val json = JSONObject().apply {
                    put("name", nama)
                    put("model", model)
                    put("brand", brand)
                    put("year",   tahun)
                    put("forSale", Forsale)
                }

                val output = DataOutputStream(conn.outputStream)
                output.write(json.toString().toByteArray())
                output.flush()
                output.close()

                val code = conn.responseCode
                GlobalScope.launch(Dispatchers.Main){
                    if(code == 404){
                        Toast.makeText(this@createData, "gagal nambah",Toast.LENGTH_SHORT).show()
                    }else{
                        Toast.makeText(this@createData, "sukses nambah",Toast.LENGTH_SHORT).show()
                        val inten = Intent(this@createData, MainActivity::class.java)
                        startActivity(inten)
                    }
                }


            }
        }
    }
}