package com.example.menampilkan_toast

import android.app.DatePickerDialog
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import java.text.SimpleDateFormat
import java.util.Calendar
import java.util.Locale

class DatePickerFormating : AppCompatActivity() {
    private lateinit var textYear: TextView
    private lateinit var textMonth: TextView
    private lateinit var textDay: TextView
    private lateinit var textFormattedDate: TextView
    private lateinit var btnPickDate: Button

    private var selectedDate: Calendar = Calendar.getInstance()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_date_picker_formating)

        textYear = findViewById(R.id.textYear)
        textMonth = findViewById(R.id.textMonth)
        textDay = findViewById(R.id.textDay)
        textFormattedDate = findViewById(R.id.textFormattedDate)
        btnPickDate = findViewById(R.id.btnPickDate)

        btnPickDate.setOnClickListener {
            showDatePickerDialog()
        }


    }

    private fun showDatePickerDialog() {
        val datePickerDialog = DatePickerDialog(
            this,
            DatePickerDialog.OnDateSetListener { _, year, month, dayOfMonth ->
                selectedDate.set(year, month, dayOfMonth)
                updateDateViews()
            },
            selectedDate.get(Calendar.YEAR),
            selectedDate.get(Calendar.MONTH),
            selectedDate.get(Calendar.DAY_OF_MONTH)
        )
        datePickerDialog.show()
    }

    private fun updateDateViews() {
        val simpleDateFormat = SimpleDateFormat("dd MMMM yyyy", Locale.getDefault())

        textYear.text = "Tahun: ${selectedDate.get(Calendar.YEAR)}"
        textMonth.text = "Bulan: ${getMonthName(selectedDate.get(Calendar.MONTH))}"
        textDay.text = "Tanggal ${selectedDate.get(Calendar.DAY_OF_MONTH)}"
        textFormattedDate.text = "${simpleDateFormat.format(selectedDate.time)}"
    }

    private fun getMonthName(month: Int): String {
        val monthNames = arrayOf(
            "Januari", "Februari", "Maret", "April",
            "Mei", "Juni", "Juli", "Agustus",
            "September", "Oktober", "November", "Desember"
        )
        return monthNames[month]
    }
}