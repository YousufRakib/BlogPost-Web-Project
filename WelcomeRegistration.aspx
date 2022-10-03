<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomeRegistration.aspx.cs" Inherits="WelcomeRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
 <title>Associate Area Dashboard :: ePlatfirm ::</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="Member/plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Tempusdominus Bootstrap 4 -->
  <link rel="stylesheet" href="Member/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="Member/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- JQVMap -->
  <link rel="stylesheet" href="Member/plugins/jqvmap/jqvmap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="Member/dist/css/adminlte.min.css">
  <!-- overlayScrollbars -->
  <link rel="stylesheet" href="Member/plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="Member/plugins/daterangepicker/daterangepicker.css">
  <!-- summernote -->
  <link rel="stylesheet" href="Member/plugins/summernote/summernote-bs4.min.css">
</head>
<body>
    <form id="form1" runat="server">
      <!-- Main content -->
    <section class="content mt-2">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">Membership Welcome</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
                    <h3 class="font-weight-bold " style="color:#3f57b9"> <span style="color:#0ec626">Congratulation!</span> Your Registration is Successfull.  </h3>    
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="card-blue">
            <asp:Label ID="lblwelcome" runat="server" />
</div>
                <table class="table " style="background-color: #ffeed4;">
            <tr>
                <td style="width:2%"> Member Id </td>
                <td style="width:10%">
                    <asp:Label id="lblmemid" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Name</td>
                <td style="width:10%"> <asp:Label id="lblname" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Sponsor Details</td>
                <td style="width:10%"> <asp:Label id="lblsponser" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Mobile No.</td>
                <td style="width:10%"> <asp:Label id="lblphn" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">E-Mail ID</td>
                <td style="width:10%"> <asp:Label id="lblmail" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Password</td>
                <td style="width:10%"> <asp:Label id="lblpass" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Date of Joining</td>
                <td style="width:10%"> <asp:Label id="lbldoj" runat="server" /></td>
            </tr>
            <tr>
                <td style="width:10%">Date of Birth</td>
                <td style="width:10%"> <asp:Label id="lbldob" runat="server" /></td>
            </tr>
        </table>
                <hr/>
                <div class="text-xl-center">
             
                <a onclick="window.print()" class="btn btn-info" > Print </a>
            </div>
                </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        
      </div>
      
    </section>
    <!-- /.content -->
 
     <asp:Label id="lblrequestid" runat="server" Visible="false" />
    </form>
    <script src="plugins/jquery/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
    $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="Member/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- ChartJS -->
<script src="Member/plugins/chart.js/Chart.min.js"></script>
<!-- Sparkline -->
<script src="Member/plugins/sparklines/sparkline.js"></script>
<!-- JQVMap -->
<script src="Member/plugins/jqvmap/jquery.vmap.min.js"></script>
<script src="Member/plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
<!-- jQuery Knob Chart -->
<script src="Member/plugins/jquery-knob/jquery.knob.min.js"></script>
<!-- daterangepicker -->
<script src="Member/plugins/moment/moment.min.js"></script>
<script src="Member/plugins/daterangepicker/daterangepicker.js"></script>
<!-- Tempusdominus Bootstrap 4 -->
<script src="Member/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
<!-- Summernote -->
<script src="Member/plugins/summernote/summernote-bs4.min.js"></script>
<!-- overlayScrollbars -->
<script src="Member/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<!-- AdminLTE App -->
<script src="Member/dist/js/adminlte.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="Member/dist/js/demo.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="Member/dist/js/pages/dashboard.js"></script>
</body>
</html>
