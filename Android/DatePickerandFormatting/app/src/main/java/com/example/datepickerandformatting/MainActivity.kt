package com.example.datepickerandformatting

import android.app.DatePickerDialog
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import java.text.SimpleDateFormat
import java.util.Calendar
import java.util.Locale

class MainActivity : AppCompatActivity() {
    private val calendar = Calendar.getInstance()
    private lateinit var textTahun: TextView
    private lateinit var textBulan: TextView
    private lateinit var textTanggal: TextView
    private lateinit var textFull: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        textTahun = findViewById<TextView>(R.id.textTahun)
        textBulan = findViewById<TextView>(R.id.textBulan)
        textTanggal = findViewById<TextView>(R.id.textTanggal)
        textFull = findViewById<TextView>(R.id.textFull)

        findViewById<Button>(R.id.pickDate).setOnClickListener {
            showDatePicker()
        }
    }

    private fun showDatePicker() {
        // Create a DatePickerDialog
        val datePickerDialog = DatePickerDialog(
            this, { DatePicker, year: Int, monthOfYear: Int, dayOfMonth: Int ->
                val selectedDate = Calendar.getInstance()
                selectedDate.set(year, monthOfYear, dayOfMonth)
                val dateFormat = SimpleDateFormat("dd MMMM yyyy", Locale.getDefault())
                val formattedDate = dateFormat.format(selectedDate.time)

                textFull.text = formattedDate
                textTahun.text = "Tahun: ${selectedDate.get(Calendar.YEAR)}"
                textBulan.text = "Bulan: ${getMonthName(selectedDate.get(Calendar.MONTH))}"
                textTanggal.text = "Tanggal: ${selectedDate.get(Calendar.DATE)}"
            },
            calendar.get(Calendar.YEAR),
            calendar.get(Calendar.MONTH),
            calendar.get(Calendar.DAY_OF_MONTH)
        )
        datePickerDialog.show()
    }
    private fun getMonthName(month: Int): String {
        val months = arrayOf("Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember")
        return months[month]
    }
}