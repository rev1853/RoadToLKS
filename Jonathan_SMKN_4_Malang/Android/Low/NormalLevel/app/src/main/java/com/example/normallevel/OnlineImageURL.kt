package com.example.normallevel

import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView
import androidx.loader.content.AsyncTaskLoader
import java.io.InputStream
import java.net.HttpURLConnection
import java.net.URL

class OnlineImageURL : AppCompatActivity() {
    lateinit var imageView: ImageView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_online_image_url)

        imageView = findViewById(R.id.imageView)
        val imageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7a/Manchester_United_FC_crest.svg/1200px-Manchester_United_FC_crest.svg.png"

        DownloadImageTask(imageView).execute(imageUrl)
    }

    private class DownloadImageTask(val imageView: ImageView) :
        AsyncTask<String, Void, Bitmap?>(){

        override fun doInBackground(vararg params: String): Bitmap? {
            val imageUrl = params[0]

            try {
                val url = URL(imageUrl)
                val conn: HttpURLConnection = url.openConnection() as HttpURLConnection
                conn.doInput = true
                conn.connect()

                val inputStream: InputStream = conn.inputStream
                return BitmapFactory.decodeStream(inputStream)

            } catch (e: Exception) {
                e.printStackTrace()
            }
            return null
        }

        override fun onPostExecute(result: Bitmap?) {
            if (result != null) {
                imageView.setImageBitmap(result)
            }
        }
    }


}