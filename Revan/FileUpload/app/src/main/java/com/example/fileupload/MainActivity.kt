package com.example.fileupload

import android.content.Intent
import android.database.Cursor
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.MediaStore
import android.provider.Settings.Global
import android.util.Log
import android.widget.Button
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    private var namaFile: String? = null
    private var uriFile: Uri? = null

    private var filePickerLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        it.data?.data?.let { uri ->
            // tereksekusi kalau data yang ada didalam data tidak null

            // mengambil metadata dari sebuah file/uri
            var projection = arrayOf(MediaStore.Files.FileColumns.DISPLAY_NAME)
            var cursor = contentResolver.query(uri, projection, null, null, null)
            cursor?.let { cursor ->
                // mencari index dari metadata yang akan diambil
                var index = cursor.getColumnIndexOrThrow(MediaStore.Files.FileColumns.DISPLAY_NAME)
                cursor.moveToFirst()
                // mengambil metadata sesuai index yang ditemukan
                var namaFile = cursor.getString(index)
                this.namaFile = namaFile
                this.uriFile = uri
            }
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        var button = findViewById<Button>(R.id.pickButton)
        button.setOnClickListener {
            var intent = Intent(Intent.ACTION_GET_CONTENT)
            intent.type = "*/*"
            filePickerLauncher.launch(intent)
        }

        findViewById<Button>(R.id.uploadButton).setOnClickListener {
            uriFile?.let {uriFile ->
                contentResolver.openInputStream(uriFile)?.let { fileStream ->

                    GlobalScope.launch(Dispatchers.IO) {
                        // setup connection ke api
                        var conn = URL("https://v2.convertapi.com/upload").openConnection() as HttpURLConnection
                        conn.requestMethod = "POST"
                        conn.doOutput = true

                        // buat boundary dan new line
                        var boundary = "*****"
                        var newLine = "\r\n"

                        // set header Content-Type dg type multipart/form-data dan boundary *****
                        conn.setRequestProperty("Content-Type", "multipart/form-data;boundary=$boundary")

                        // buka ouput stream dari connection
                        var outputStream = DataOutputStream(conn.outputStream)
                        // tulis batas/boundary awal --<boundary>\r\n
                        outputStream.writeBytes("--$boundary$newLine")

                        // awal part 1 (file)
                        // tulis metadata Content-Disposition form-data, name: file, filename: <sesuai nama file>
                        outputStream.writeBytes("Content-Disposition: form-data; name=file; filename=$namaFile$newLine$newLine")

                        // kirim stream dari file yang dipilih ke output stream
                        fileStream.copyTo(outputStream)

                        // tulis new line
                        outputStream.writeBytes(newLine)
                        // tulis batas akhir --<boundary>--\r\n
                        outputStream.writeBytes("--$boundary--$newLine")

                        // menutup stream yang dipakai
                        fileStream.close()
                        outputStream.flush()
                        outputStream.close()

                        // cek jika response code 2xx ambil result yang berupa json
                        var responseCode = conn.responseCode

                        if (responseCode in 200..299) {
                            var result = conn.inputStream.bufferedReader().readText()

                            runOnUiThread {
                                Log.d("UPLOAD_FILE", result)
                                Toast.makeText(this@MainActivity, result, Toast.LENGTH_LONG).show()
                            }
                        }
                    }

                }
            }
        }
    }
}