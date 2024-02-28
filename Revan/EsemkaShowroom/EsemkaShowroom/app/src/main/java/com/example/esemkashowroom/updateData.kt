package com.example.esemkashowroom

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.Settings.Global
import android.util.Log
import android.widget.Toast
import androidx.appcompat.widget.AppCompatButton
import com.example.esemkashowroom.databinding.ActivityUpdateDataBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class updateData : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        var binding = ActivityUpdateDataBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val data = intent.getStringExtra("updateData")
        val json = JSONObject(data)

        binding.uNama.setText(json.getString("name"))
        binding.uModel.setText(json.getString("model"))
        binding.uBrand.setText(json.getString("brand"))
        binding.uTahun.setText(json.getString("year"))

        if (json.getBoolean("forSale")) {
            binding.uYes.isChecked = true
        } else {
            binding.uNo.isChecked = true
        }

        findViewById<AppCompatButton>(R.id.u_update).setOnClickListener {
            var dataYangMauDikirim = JSONObject().apply {
                put("name", binding.uNama.text.toString())
                put("model", binding.uModel.text.toString())
                put("brand", binding.uBrand.text.toString())
                put("year", binding.uTahun.text.toString())
                put("forSale", binding.uYes.isChecked)
            }
            Log.d("CEK_NILAI", json.toString())

            GlobalScope.launch(Dispatchers.IO) {
                var conn = URL("https://6597231a668d248edf22a0d3.mockapi.io/Cars/${json.getString("id")}").openConnection() as HttpURLConnection
                conn.requestMethod = "PUT"
                conn.doOutput = true
                conn.setRequestProperty("Content-Type", "application/json")

                DataOutputStream(conn.outputStream).use {
                    it.writeBytes(dataYangMauDikirim.toString())
                    it.flush()
                }

                var code = conn.responseCode

                runOnUiThread {
                    if (code in 200.. 299) {
                        Toast.makeText(this@updateData, "Sukses Update Data", Toast.LENGTH_LONG).show()
                        finish()
                    } else {
                        Toast.makeText(this@updateData, "Gagal Update Data", Toast.LENGTH_LONG).show()
                    }
                }
            }
        }
    }
}