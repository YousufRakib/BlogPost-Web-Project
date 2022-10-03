<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PublicUser/MasterPage.master" CodeFile="Public.aspx.cs" Inherits="PublicUser_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <title>Blooger</title>

        <!-- Font Awesome Icons -->
        <link rel="stylesheet" href="./css/all.css">


        <!-- --------- Owl-Carousel ------------------->
        <link rel="stylesheet" href="./css/owl.carousel.min.css">
        <link rel="stylesheet" href="./css/owl.theme.default.min.css">

        <!-- ------------ AOS Library ------------------------- -->
        <link rel="stylesheet" href="./css/aos.css">
        <link rel="stylesheet" href="./css/easyPaginate.css">

        <!-- Custom Style   -->
        <link rel="stylesheet" href="./css/Style.css">

        <style>
            .btnclass {
                border-radius: 0;
                padding: 0.7rem 1rem;
                background: var(--sky);
                border: none;
                font-size: 1rem !important;
                font-family: var(--Livvic);
                cursor: pointer;
            }
        </style>
    </head>
    <body>

        <form id="form1">

            <nav class="nav">
                <div class="nav-menu flex-row">
                    <div class="nav-brand">
                        <a href="#" class="text-gray">Blooger</a>
                    </div>
                    <div class="toggle-collapse">
                        <div class="toggle-icons">
                            <i class="fas fa-bars"></i>
                        </div>
                    </div>
                    <div>
                        <ul class="nav-items">
                            <li class="nav-link">
                                <a href="public.aspx">Home</a>
                            </li>
                            <li class="nav-link">
                                <a href="#">Category</a>
                            </li>
                            <li class="nav-link">
                                <a href="#">Archive</a>
                            </li>
                            <li class="nav-link">
                                <a href="#">Pages</a>
                            </li>
                            <li class="nav-link">
                                <a href="#">Contact Us</a>
                            </li>
                        </ul>
                    </div>
                    <div class="d-none">
                        <div class="social text-gray">
                            <%--     <a href="#"><i class="fab fa-facebook-f"></i></a>
                    <a href="#"><i class="fab fa-instagram"></i></a>
                    <a href="#"><i class="fab fa-twitter"></i></a>
                    <a href="#"><i class="fab fa-youtube"></i></a>--%>
                        </div>
                    </div>
                </div>
            </nav>

            <!-- ------------x---------------  Navigation --------------------------x------------------- -->

            <!----------------------------- Main Site Section ------------------------------>

            <main>




                <section>
                    <div class="blog">
                        <div class="container">



                            <div id="div1" runat="server"></div>


                            <div class="owl-navigation">
                                <span class="owl-nav-prev"><i class="fas fa-long-arrow-alt-left"></i></span>
                                <span class="owl-nav-next"><i class="fas fa-long-arrow-alt-right"></i></span>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- ----------x---------- Blog Carousel --------x-------- -->

                <!-- ---------------------- Site Content -------------------------->

                <section class="container">
                    <div class="site-content">

                        <div class="posts">

                            <div id="div2" runat="server"></div>



                            <div id="divProductsPagination" class="col-xs-12 col-sm-12 col-md-12 col-lg-12" runat="server"></div>


                            <div class="pagination">
                                <div id="demo5" class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
                            </div>
                        </div>
                        <aside class="sidebar">
                            <div class="category">
                                <h2>Category</h2>
                                <div id="divMainCardBody" class="category-list" runat="server"></div>
                                <%--        <ul class="category-list">
                            <li class="list-items" data-aos="fade-left" data-aos-delay="100">
                                <a href="#">Software</a>
                                <span>(05)</span>
                            </li>
                            <li class="list-items" data-aos="fade-left" data-aos-delay="200">
                                <a href="#">Techonlogy</a>
                                <span>(02)</span>
                            </li>
                            <li class="list-items" data-aos="fade-left" data-aos-delay="300">
                                <a href="#">Lifestyle</a>
                                <span>(07)</span>
                            </li>
                            <li class="list-items" data-aos="fade-left" data-aos-delay="400">
                                <a href="#">Shopping</a>
                                <span>(01)</span>
                            </li>
                            <li class="list-items" data-aos="fade-left" data-aos-delay="500">
                                <a href="#">Food</a>
                                <span>(08)</span>
                            </li>
                        </ul>--%>
                            </div>
                            <%--   <div class="popular-post">
                            <h2>Popular Post</h2>
                            <div class="post-content" data-aos="flip-up" data-aos-delay="200">
                                <div class="post-image">
                                    <div>
                                        <img src="./assets/popular-post/m-blog-1.jpg" class="img" alt="blog1">
                                    </div>
                                    <div class="post-info flex-row">
                                        <span><i class="fas fa-calendar-alt text-gray"></i>&nbsp;&nbsp;January 14,
                                        2019</span>
                                        <span>2 Commets</span>
                                    </div>
                                </div>
                                <div class="post-title">
                                    <a href="#">New data recording system to better analyse road accidents</a>
                                </div>
                            </div>
                            <div class="post-content" data-aos="flip-up" data-aos-delay="300">
                                <div class="post-image">
                                    <div>
                                        <img src="./assets/popular-post/m-blog-2.jpg" class="img" alt="blog1">
                                    </div>
                                    <div class="post-info flex-row">
                                        <span><i class="fas fa-calendar-alt text-gray"></i>&nbsp;&nbsp;January 14,
                                        2019</span>
                                        <span>2 Commets</span>
                                    </div>
                                </div>
                                <div class="post-title">
                                    <a href="#">New data recording system to better analyse road accidents</a>
                                </div>
                            </div>
                            <div class="post-content" data-aos="flip-up" data-aos-delay="400">
                                <div class="post-image">
                                    <div>
                                        <img src="./assets/popular-post/m-blog-3.jpg" class="img" alt="blog1">
                                    </div>
                                    <div class="post-info flex-row">
                                        <span><i class="fas fa-calendar-alt text-gray"></i>&nbsp;&nbsp;January 14,
                                        2019</span>
                                        <span>2 Commets</span>
                                    </div>
                                </div>
                                <div class="post-title">
                                    <a href="#">New data recording system to better analyse road accidents</a>
                                </div>
                            </div>
                            <div class="post-content" data-aos="flip-up" data-aos-delay="500">
                                <div class="post-image">
                                    <div>
                                        <img src="./assets/popular-post/m-blog-4.jpg" class="img" alt="blog1">
                                    </div>
                                    <div class="post-info flex-row">
                                        <span><i class="fas fa-calendar-alt text-gray"></i>&nbsp;&nbsp;January 14,
                                        2019</span>
                                        <span>2 Commets</span>
                                    </div>
                                </div>
                                <div class="post-title">
                                    <a href="#">New data recording system to better analyse road accidents</a>
                                </div>
                            </div>
                            <div class="post-content" data-aos="flip-up" data-aos-delay="600">
                                <div class="post-image">
                                    <div>
                                        <img src="./assets/popular-post/m-blog-5.jpg" class="img" alt="blog1">
                                    </div>
                                    <div class="post-info flex-row">
                                        <span><i class="fas fa-calendar-alt text-gray"></i>&nbsp;&nbsp;January 14,
                                        2019</span>
                                        <span>2 Commets</span>
                                    </div>
                                </div>
                                <div class="post-title">
                                    <a href="#">New data recording system to better analyse road accidents</a>
                                </div>
                            </div>
                        </div>
                        <div class="newsletter" data-aos="fade-up" data-aos-delay="300">
                            <h2>Newsletter</h2>
                            <div class="form-element">
                                <input type="text" class="input-element" placeholder="Email">
                                <button class="btn form-btn">Subscribe</button>
                            </div>
                        </div>
                        <div class="popular-tags">
                            <h2>Popular Tags</h2>
                            <div class="tags flex-row">
                                <span class="tag" data-aos="flip-up" data-aos-delay="100">Software</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="200">technology</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="300">travel</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="400">illustration</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="500">design</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="600">lifestyle</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="700">love</span>
                                <span class="tag" data-aos="flip-up" data-aos-delay="800">project</span>
                            </div>
                        </div>--%>
                        </aside>
                    </div>
                </section>

                <!-- -----------x---------- Site Content -------------x------------>

            </main>

            <!---------------x------------- Main Site Section ---------------x-------------->


            <!-- --------------------------- Footer ---------------------------------------- -->

            <footer class="footer">
                <div class="container">
                    <div class="about-us" data-aos="fade-right" data-aos-delay="200">
                        <h2>About us</h2>
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusantium quia atque nemo ad modi officiis
                    iure, autem nulla tenetur repellendus.
                        </p>
                    </div>
                    <div class="newsletter" data-aos="fade-right" data-aos-delay="200">
                        <h2>Newsletter</h2>
                        <p>Stay update with our latest</p>
                        <div class="form-element">
                            <input type="text" placeholder="Email"><span><i class="fas fa-chevron-right"></i></span>
                        </div>
                    </div>
                    <div class="instagram" data-aos="fade-left" data-aos-delay="200">
                        <h2>Instagram</h2>
                        <div class="flex-row">
                            <img src="./assets/instagram/thumb-card3.png" alt="insta1">
                            <img src="./assets/instagram/thumb-card4.png" alt="insta2">
                            <img src="./assets/instagram/thumb-card5.png" alt="insta3">
                        </div>
                        <div class="flex-row">
                            <img src="./assets/instagram/thumb-card6.png" alt="insta4">
                            <img src="./assets/instagram/thumb-card7.png" alt="insta5">
                            <img src="./assets/instagram/thumb-card8.png" alt="insta6">
                        </div>
                    </div>
                    <%--     <div class="follow " data-aos="fade-left" data-aos-delay="200">
                    <h2>Follow us</h2>
                    <p>Let us be Social</p>
                    <div>
                        <i class="fab fa-facebook-f"></i>
                        <i class="fab fa-twitter"></i>
                        <i class="fab fa-instagram"></i>
                        <i class="fab fa-youtube"></i>
                    </div>
                </div>--%>
                </div>
                <div class="rights flex-row">
                    <h4 class="text-gray">Copyright ©2019 All rights reserved | made by
               
                    <a href="http://romswebcreator.in/" target="_black">RomsWebCreator </a>
                    </h4>
                </div>
                <div class="move-up">
                    <span><i class="fas fa-arrow-circle-up fa-2x"></i></span>
                </div>
            </footer>

            <!-- -------------x------------- Footer --------------------x------------------- -->

            <!-- Jquery Library file -->
            <script src="./js/Jquery3.4.1.min.js"></script>

            <!-- --------- Owl-Carousel js ------------------->
            <script src="./js/owl.carousel.min.js"></script>

            <!-- ------------ AOS js Library  ------------------------- -->
            <script src="./js/aos.js"></script>
            <script src="./js/jquery.easyPaginate.js"></script>

            <!-- Custom Javascript file -->
            <script src="./js/main.js"></script>

            <script>
                $("#demo5").paginate({
                    count: 10,
                    start: 1,
                    display: 5,
                    border: true,
                    border_color: '#fff',
                    text_color: '#fff',
                    background_color: '#80bf27',
                    border_hover_color: '#ccc',
                    text_hover_color: '#000',
                    background_hover_color: '#fff',
                    images: false,
                    mouse: 'press',
                    onChange: function (page) {
                        $('._current', '#ContentPlaceHolder1_divProductsPagination').removeClass('_current').hide();
                        $('#p' + page).addClass('_current').show();
                    }
                });
            </script>
        </form>
    </body>
    </html>

</asp:Content>
