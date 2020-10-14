/*!
 * jquery-quiz v0.0.1 - A simple jQuery quiz plugin.
 * Copyright (c) 2018 JC Hamill - http://jchamill.github.com/jquery-quiz/
 * License: MIT
 */

var nextquitLink = "";
if (sessionStorage.getItem("QuizNumber") == "1") {

    nextquitLink = '<p><a href="/Home/Quiz2" id="back-btn" class="quiz-button" ">Next Quiz</a></p>';
}
if (sessionStorage.getItem("QuizNumber") == "2") {

    nextquitLink = '<p><a href="/Home/Quiz3" id="back-btn" class="quiz-button" ">Next Quiz</a></p>';
}
if (sessionStorage.getItem("QuizNumber") == "3") {

    nextquitLink = "";
}

nextquitLink = '<p><a href="/Home/Quiz2" id="back-btn" class="quiz-button" ">Next Quiz</a></p>';
! function (a, b, c, d) {
    "use strict";
    a.quiz = function (b, d) {
        var e = this;
        e.$el = a(b), e.$el.data("quiz", e), e.options = a.extend(a.quiz.defaultOptions, d);
        var f = e.options.questions,
            g = f.length,
            h = e.options.startScreen,
            i = e.options.startButton,
            j = e.options.homeButton,
            k = e.options.resultsScreen,
            l = e.options.gameOverScreen,
            m = e.options.nextButtonText,
            n = e.options.finishButtonText,
            o = e.options.restartButtonText,
            p = 1,
            q = 0,
            r = !1;
        var quiz3Score = 0;
        e.methods = {
            init: function () {
                e.methods.setup(), a(c).on("click", i, function (a) {
                    a.preventDefault(), e.methods.start()
                }), a(c).on("click", j, function (a) {
                    a.preventDefault(), e.methods.home()
                }), a(c).on("click", ".answers a", function (a) {
                    a.preventDefault(), e.methods.answerQuestion(this)
                }), a(c).on("click", "#quiz-next-btn", function (a) {
                    a.preventDefault(), e.methods.nextQuestion()
                }), a(c).on("click", "#quiz-finish-btn", function (a) {
                    a.preventDefault(), e.methods.finish()
                }), a(c).on("click", "#quiz-restart-btn, #quiz-retry-btn", function (a) {
                    a.preventDefault(), e.methods.restart()
                })
            },
            setup: function () {
                var b = "";
                e.options.counter && (b += '<div id="quiz-counter"></div>'), b += '<div id="questions">', a.each(f, function (c, d) {
                    b += '<div class="question-container">', b += '<p class="question">' + d.q + "</p>", b += '<ul class="answers">', a.each(d.options, function (a, c) {
                        b += '<li><a href="#" data-index="' + a + '">' + c + "</a></li>"
                    }), b += "</ul>", b += "</div>"
                }), b += "</div>", 0 === a(k).length && (b += '<div id="' + k.substr(1) + '">', b += '<p id="quiz-results"></p>', b += "</div>"), b += '<div id="quiz-controls">', b += '<p id="quiz-response"></p>', b += '<div id="quiz-buttons">', b += '<a href="#" id="quiz-next-btn">' + m + "</a>", b += '<a href="#" id="quiz-finish-btn">' + n + "</a>", b += '' + o + "</a>", b += "</div>", b += "</div>", e.$el.append(b).addClass("quiz-container quiz-start-state"), a("#quiz-counter").hide(), a(".question-container").hide(), a(l).hide(), a(k).hide(), a("#quiz-controls").hide()
            },
            start: function () {

                e.$el.removeClass("quiz-start-state").addClass("quiz-questions-state"), a(h).hide(), a("#quiz-controls").hide(), a("#quiz-finish-btn").hide(), a("#quiz-restart-btn").hide(), a("#questions").show(), a("#quiz-counter").show(), a(".question-container:first-child").show().addClass("active-question"), e.methods.updateCounter()
            },
            answerQuestion: function (b) {

                if (!r) {
                    r = !0;
                    var c = a(b),
                        d = "",
                        g = c.data("index"),
                        h = p - 1,
                        i = f[h].correctIndex;
                    if (g === i) {
                        c.addClass("correct"), d = f[h].correctResponse, q++;
                        if (p < 3) {
                            quiz3Score = quiz3Score + 3;
                        };
                        if (p == 3 || p == 4 || p == 5) {
                            quiz3Score = quiz3Score + 4;
                        };
                        if (p > 5) {
                            quiz3Score = quiz3Score + 3;
                        };


                    }

                    else if (c.addClass("incorrect"), d = f[h].incorrectResponse, !e.options.allowIncorrect) return void e.methods.gameOver(d);
                    a("#quiz-response").html(d), a("#quiz-controls").fadeIn(), "function" == typeof e.options.answerCallback && e.options.answerCallback(p, g, f[h])
                }

            },
            nextQuestion: function () {
                r = !1, a(".active-question").hide().removeClass("active-question").next(".question-container").show().addClass("active-question"), a("#quiz-controls").hide(), ++p === g && (a("#quiz-next-btn").hide(), a("#quiz-finish-btn").show()), e.methods.updateCounter(), "function" == typeof e.options.nextCallback && e.options.nextCallback()
            },
            gameOver: function (b) {

                if (0 === a(l).length) {
                    var c = "";
                    c += '<div id="' + l.substr(1) + '">', c += '<p id="quiz-gameover-response"></p>', c += '<p><a href="#" id="quiz-retry-btn">' + o + "</a></p>", c += "</div>", e.$el.append(c)
                }
                a("#quiz-gameover-response").html(b), a("#quiz-counter").hide(), a("#questions").hide(), a("#quiz-finish-btn").hide(), a(l).show()
            },
            finish: function () {
                if (sessionStorage.getItem("QuizNumber") == "1") {

                    sessionStorage.setItem("QUIZ1RESULT", q * 10);
                }
                if (sessionStorage.getItem("QuizNumber") == "2") {

                    sessionStorage.setItem("QUIZ2RESULT", q * 10);
                }
                if (sessionStorage.getItem("QuizNumber") == "3") {

                    sessionStorage.setItem("QUIZ3RESULT", quiz3Score);
                }


                e.$el.removeClass("quiz-questions-state").addClass("quiz-results-state"), a(".active-question").hide().removeClass("active-question"), a("#quiz-counter").hide(), a("#quiz-response").hide(), a("#quiz-finish-btn").hide(), a("#quiz-next-btn").hide(), a("#quiz-restart-btn").show(), a(k).show();
                var b = e.options.resultsFormat.replace("%score", q).replace("%total", g);
                a("#quiz-results").html(b), "function" == typeof e.options.finishCallback && e.options.finishCallback()
            },
            restart: function () {
                //e.methods.reset(), e.$el.addClass("quiz-questions-state"), a("#questions").show(), a("#quiz-counter").show(), a(".question-container:first-child").show().addClass("active-question"), e.methods.updateCounter()
            },
            reset: function () {
                r = !1, p = 1, q = 0, a(".answers a").removeClass("correct incorrect"), e.$el.removeClass().addClass("quiz-container"), a("#quiz-restart-btn").hide(), a(l).hide(), a(k).hide(), a("#quiz-controls").hide(), a("#quiz-response").show(), a("#quiz-next-btn").show(), a("#quiz-counter").hide(), a(".active-question").hide().removeClass("active-question")
            },
            home: function () {
                e.methods.reset(), e.$el.addClass("quiz-start-state"), a(h).show(), "function" == typeof e.options.homeCallback && e.options.homeCallback()
            },
            updateCounter: function () {
                var b = e.options.counterFormat.replace("%current", p).replace("%total", g);
                a("#quiz-counter").html(b)
            }
        }, e.methods.init()
    }, a.quiz.defaultOptions = {
        allowIncorrect: !0,
        counter: !0,
        counterFormat: "%current/%total",
        startScreen: "#quiz-start-screen",
        startButton: "#quiz-start-btn",
        homeButton: "#quiz-home-btn",
        resultsScreen: "#quiz-results-screen",
        resultsFormat: "You got %score out of %total correct! " + nextquitLink + '<p><a href="/Home/Quiz/#quiz" id="back-btn" class="quiz-button" ">Quit</a></p>',
        gameOverScreen: "#quiz-gameover-screen",
        nextButtonText: "Next",
        finishButtonText: "Finish",
        restartButtonText: ""
    }, a.fn.quiz = function (b) {
        return this.each(function () {
            new a.quiz(this, b)
        })
    }
}(jQuery, window, document);
