package com.example.jwthandling

class Test {
    fun ff() {
        val input = Scanner(System.`in`)
        val N = input.nextInt()

        var total = 0
        for (i in 2..N) {
            if (i % 2 == 0) total += i
        }
    }
}