package com.example.simpleformanddatapassing

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.RadioButton
import android.widget.RadioGroup
import org.json.JSONObject

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<RadioGroup>(R.id.radioGrub).setOnCheckedChangeListener { radioGroup, i ->
            if (i == R.id.radioLakiLaki) {
                findViewById<RadioButton>(R.id.radioLakiLaki).isChecked = true
                findViewById<RadioButton>(R.id.radioPerempuan).isChecked = false
            } else {
                findViewById<RadioButton>(R.id.radioLakiLaki).isChecked = false
                findViewById<RadioButton>(R.id.radioPerempuan).isChecked = true
            }
        }

        findViewById<Button>(R.id.buttonSubmit).setOnClickListener {
            var bahasa:String = "";

            if (findViewById<CheckBox>(R.id.checkHTML).isChecked) bahasa += "HTML, "
            if (findViewById<CheckBox>(R.id.checkCSS).isChecked) bahasa += "CSS, "
            if (findViewById<CheckBox>(R.id.checkJSON).isChecked) bahasa += "JSON, "
            if (findViewById<CheckBox>(R.id.checkXML).isChecked) bahasa += "XML"

            val data = JSONObject().apply {
                put("name", findViewById<EditText>(R.id.editName).text)
                put("jenis_kelamin", if (findViewById<RadioButton>(R.id.radioLakiLaki).isChecked == true) "Laki-Laki" else "Perempuan")
                put("bahasa_pemerogaman", bahasa)
            }

            startActivity(Intent(this, MainActivity2::class.java).apply {
                putExtra("data", data.toString())
            })
        }
    }
}