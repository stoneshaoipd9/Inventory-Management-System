   M S B A M L   `   `   `  ����D  @AutoParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AutoParts	AutoParts  5   	       AutoParts.ModifyEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AutoParts     5   	     � Title$  ModifyEmployee��5   	   $��537.5��6!   $	��990��60    � 
ResizeMode$ CanResizeWithGrip=�6<   .��5	      � 
�������$��0,0,2,3q�6"   .+�5
   
   �� -   5        $��lvModifyEmployeeList��5
      $��14(�60   $
��Bold"�6?   $��10,98,16,136q�6�    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 40��61    �� DisplayMemberBinding 6<   �� *
EmployeeId+�� 5      $��
First Name��6%   $	 200��69    6E   �� *	FirstName+�� 5      $��	Last Name��6%   $	 200��68    6D   �� *
LastName+�� 5      $��	User Name��6%   $	 200��68    6D   �� *
UserName+�� 5      $��Password��6%   $	 200��67    6C   �� *
Password+�� 5      $��Is Admin��6%   $	 100��67    6C   �� *	IsAdmin+5      5      �� 5   
   $��Sort by��6   $��20(�6"   $
��Bold"�60   $
��Left=�6B   $��	10,29,0,0q�6]   $	��Top=�6p   $��2��6�   �� 5   
   -   5        $��comboMESortBy��5      $��14(�6(   $
��Bold"�67   $
��Left=�6�   $��
109,38,0,0q�6�   $	��Top=�6�   $	��320��6�   .@�5      �� $��ID��6   �� 5      $��
First Name��6   �� 5      $��	Last Name��6   �� 5      $��	User Name��6   �� 5      $��Password��6   �� 5      $��Is Admin��6   5      �� 5   
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
   $��Employee Detail��6   $��14(�6,   $
��Bold"�6;   $
��Left=�6N   $	��116��6i   $��
10,374,0,0q�6v   $	��Top=�6�   $	��954��6�   �� 5%   
   $��Password��6   $
��Left=�6#   $��565,445,0,0q�6>   $	��Top=�6S    J� RenderTransformOrigin$ -5.341,0.577&�6k   �� 5&   
   $��	Last Name��6   $
��Left=�6$   $��565,408,0,0q�6?   $	��Top=�6T   $ 0.67,0.5&�6l   �� 5'   
   $��Is Admin��6   $
��Left=�6#   $��
34,446,0,0q�6>   $	��Top=�6R   �� 5(   
   $��	User Name��6   $
��Left=�6$   $��185,446,0,0q�6?   $	��Top=�6T   �� 5)   
   $��
First Name��6   $
��Left=�6%   $��138,407,0,0q�6@   $	��Top=�6U   $ 4.079,10.654&�6m   �� 5*   
   $	��Id:��6   $
��Left=�6   $��
34,406,0,0q�69   $	��Top=�6M   $ 0.518,-0.853&�6e   �� 5+   
   -   5        $��lblMEId��5+      $	��...��6   $
��Left=�6-   $��
59,407,0,0q�6H   $	��Top=�6\   $ 0.518,-0.853&�6t   $��79��6�   �� 5,   
   -	   5        $��tbMELastName��5,      $
��Left=�6&   $��23��6A   $��636,411,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��299��6�   �� 5-   
   -
   5        $��tbMEIsAdmin��5-      $
��Left=�6%   $��23��6@   $��
98,449,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��64��6�   �� 5.   
   -   5        $��tbMEUserName��5.      $
��Left=�6&   $��23��6A   $��259,448,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��290��6�   �� 5/   
   -   5        $��tbMEFirstName��5/      $
��Left=�6'   $��23��6B   $��210,410,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��339��6�   �� 50   
   -   5        $��tbMEPassword��50      $
��Left=�6&   $��23��6A   $��636,448,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��299��6�   54      55      