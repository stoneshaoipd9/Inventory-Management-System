   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts  5   	       AutoParts.ModifyCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AutoParts     5   	     � Title$  Modify Customer Window��5   	   $	��530��6(   $	��984��65    � 
ResizeMode$ CanResizeWithGrip=�6A   .��5	      � 
�������.+�5
   
   �� -   5        $��lvModifyCustomerList��5
      $��14(�60   $
��Bold"�6?   $��10,98,12,133q�6�    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 40��61    �� DisplayMemberBinding 6<   �� *CustSupplierId+�� 5      $��Company Name��6%   $	 200��6;    6G   �� *CompanyName+�� 5      $��Contact Name��6%   $	 120��6;    6G   �� *ContactName+�� 5      $��Contact Title��6%   $	 120��6<    6H   �� *ContactTitle+�� 5      $��Address��6%   $	 350��66    6B   �� *	Address+�� 5      $��Phone��6%   $	 120��64    6@   �� *Phone+5      5      �� 5   
   $��Sort by��6   $��20(�6"   $
��Bold"�60   $
��Left=�6B   $��	10,29,0,0q�6]   $	��Top=�6p   $��2��6�   �� 5   
   -   5        $��comboMCSortBy��5      $��14(�6(   $
��Bold"�67   $
��Left=�6�   $��
109,38,0,0q�6�   $	��Top=�6�   $	��320��6�   .@�5      �� $��ID��6   �� 5      $��Company Name��6   �� 5      $��Contact Name��6   �� 5      $��Contact Title��6   �� 5      $��Address��6   �� 5      $��Phone��6   5      �� 5   
   -   5        $��btnMCAdd��5      $	��Add��6!   $��14(�60   $
��Bold"�6?   $
��Left=�6i   $��
474,38,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5    
   -   5        $��btnMCRemove��5       $��Remove��6$   $��14(�66   $
��Bold"�6E   $
��Left=�6r   $��
574,38,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5!   
   -   5        $��btnMCUpdate��5!      $��Update��6$   $��14(�66   $
��Bold"�6E   $
��Left=�6r   $��
676,38,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5"   
   -   5        $��btnMCRefresh��5"      $��Refresh��6%   $��14(�68   $
��Bold"�6G   $
��Left=�6u   $��
773,38,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5#   
   -   5        $��btnMCReturn��5#      $��Return��6$   $��14(�66   $
��Bold"�6E   $
��Left=�6r   $��
870,38,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5$   
   $��Customer Detail��6   $��14(�6,   $
��Bold"�6;   $
��Left=�6N   $	��116��6i   $��
10,374,0,0q�6v   $	��Top=�6�   $	��954��6�   �� 5%   
   $��Phone��6   $
��Left=�6    $��432,446,0,0q�6;   $	��Top=�6P    J� RenderTransformOrigin$ -5.341,0.577&�6h   �� 5&   
   $��Address��6   $
��Left=�6"   $��623,408,0,0q�6=   $	��Top=�6R   $ 0.67,0.5&�6j   �� 5'   
   $��Contact Title��6   $
��Left=�6(   $��
34,446,0,0q�6C   $	��Top=�6W   �� 5(   
   $��Contact Name��6   $
��Left=�6'   $��194,446,0,0q�6B   $	��Top=�6W   �� 5)   
   $��Company Name��6   $
��Left=�6'   $��138,407,0,0q�6B   $	��Top=�6W   $ 4.079,10.654&�6o   �� 5*   
   $	��Id:��6   $
��Left=�6   $��
34,406,0,0q�69   $	��Top=�6M   $ 0.518,-0.853&�6e   �� 5+   
   -   5        $��lblMCId��5+      $	��...��6   $
��Left=�6-   $��
59,407,0,0q�6H   $	��Top=�6\   $ 0.518,-0.853&�6t   $��79��6�   �� 5,   
   -	   5        $��tbMCAddress��5,      $
��Left=�6%   $��61��6@   $��681,411,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��264��6�   �� 5-   
   -
   5        $��tbMCContactTitle��5-      $
��Left=�6*   $��23��6E   $��116,449,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $��64��6�   �� 5.   
   -   5        $��tbMCContactName��5.      $
��Left=�6)   $��23��6D   $��285,448,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��133��6�   �� 5/   
   -   5        $��tbMCCompanyName��5/      $
��Left=�6)   $��23��6D   $��234,410,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��367��6�   �� 50   
   -   5        $��	tbMCPhone��50      $
��Left=�6#   $��23��6>   $��481,449,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   52      53      