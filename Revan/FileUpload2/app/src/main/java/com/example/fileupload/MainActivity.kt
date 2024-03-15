package com.example.fileupload

import android.content.Intent
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.MediaStore
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {

    private var uri: Uri? = null
    private var name: String? = null

    private val launcher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) {
        it.data?.data?.let { uri ->
            this.uri = uri
            val proj = arrayOf(MediaStore.Files.FileColumns.DISPLAY_NAME, MediaStore.Files.FileColumns.SIZE)
            val cursor = contentResolver.query(uri, proj, null, null, null)
            cursor?.let {
                cursor.moveToFirst()
                val indexName = cursor.getColumnIndex(MediaStore.Files.FileColumns.DISPLAY_NAME)
                this.name = cursor.getString(indexName)
                val indexSize = cursor.getColumnIndex(MediaStore.Files.FileColumns.SIZE)
                val size = cursor.getInt(indexSize)
                findViewById<TextView>(R.id.name_file_tv).text = "$name ($size)"
            }
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<Button>(R.id.pick_btn).setOnClickListener {
            launcher.launch(Intent(Intent.ACTION_GET_CONTENT).apply {
                type = "image/*"
            })
        }

        findViewById<Button>(R.id.upload_btn).setOnClickListener {
            uri?.let {
                contentResolver.openInputStream(it)?.let { fileStream ->
                    GlobalScope.launch(Dispatchers.IO) {
                        val boundary = "asus-tuf"

                        val conn = URL("https://v2.convertapi.com/upload").openConnection() as HttpURLConnection
                        conn.requestMethod = "POST"
                        conn.setRequestProperty("Content-Type", "multipart/form-data; boundary=$boundary")

                        val body = DataOutputStream(conn.outputStream)

                        // file
                        body.writeBytes("--$boundary\r\n")
                        body.writeBytes("Content-Disposition: form-data; name=\"file\"; filename=$name\r\n\r\n")
                        fileStream.copyTo(body)
                        body.writeBytes("\r\n")

                        // text
                        body.writeBytes("--$boundary\r\n")
                        body.writeBytes("Content-Disposition: form-data; name=\"name\"; ")
                        body.writeBytes("revan")
                        body.writeBytes("\r\n")

                        body.writeBytes("--$boundary--\r\n")

                        body.flush()
                        body.close()


                        val code = conn.responseCode

                        if (code in 200 .. 299) {
                            val data = JSONObject(conn.inputStream.bufferedReader().readText())
                            runOnUiThread {
                                findViewById<TextView>(R.id.name_file_tv).text = data.getString("Url")
                            }
                        } else {
                            val data = conn.errorStream.bufferedReader().readText()
                            runOnUiThread {
                                Toast.makeText(this@MainActivity, "Ada error, errornya: $data", Toast.LENGTH_SHORT).show()
                            }
                        }
                    }
                }
            }
        }
    }
}