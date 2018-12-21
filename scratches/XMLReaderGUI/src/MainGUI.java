import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import javax.swing.plaf.ProgressBarUI;
import javax.swing.plaf.basic.BasicProgressBarUI;
import javax.swing.SpringLayout;
import javax.swing.JButton;
import java.awt.Component;
import javax.swing.Box;
import java.awt.BorderLayout;
import com.jgoodies.forms.layout.FormLayout;
import com.jgoodies.forms.layout.ColumnSpec;
import com.jgoodies.forms.layout.RowSpec;
import com.jgoodies.forms.layout.FormSpecs;
import java.awt.FlowLayout;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.Font;
import javax.swing.JProgressBar;
import java.awt.Color;

public class MainGUI {

	private JFrame frame;
	private JTextField txtInputDir;
	private JButton btnImportarDatos;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainGUI window = new MainGUI();
					window.frame.setVisible(true);
					String title = "Eggs";
					/*JOptionPane.showMessageDialog(window.frame,
							"Eggs are not supposed to be green.",
							"Eggs",
							JOptionPane.ERROR_MESSAGE);*/


				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public MainGUI() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		try {
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (InstantiationException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (UnsupportedLookAndFeelException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		frame = new JFrame();
		frame.setTitle("Importar XML");
		frame.setBounds(100, 100, 450, 228);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		JLabel txtSeleccionar = new JLabel("Selecciona un *.xml para importar");
		txtSeleccionar.setFont(new Font("Tahoma", Font.PLAIN, 12));
		txtSeleccionar.setForeground(new Color(0, 0, 0));
		txtSeleccionar.setBounds(10, 11, 303, 20);
		frame.getContentPane().add(txtSeleccionar);
		
		txtInputDir = new JTextField();
		txtInputDir.setFont(new Font("Tahoma", Font.PLAIN, 12));
		txtInputDir.setBounds(10, 42, 303, 20);
		frame.getContentPane().add(txtInputDir);
		txtInputDir.setColumns(10);
		
		JButton btnAbrir = new JButton("Abrir");
		btnAbrir.setFont(new Font("Tahoma", Font.PLAIN, 12));
		btnAbrir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
			}
		});
		btnAbrir.setBounds(323, 41, 89, 23);
		frame.getContentPane().add(btnAbrir);
		
		btnImportarDatos = new JButton("Importar Datos");
		btnImportarDatos.setFont(new Font("Tahoma", Font.PLAIN, 14));
		btnImportarDatos.setBounds(150, 75, 150, 40);
		frame.getContentPane().add(btnImportarDatos);
		
		JProgressBar progressBar = new JProgressBar();
		progressBar.setFont(new Font("Tahoma", Font.PLAIN, 14));
		progressBar.setValue(50);
		progressBar.setStringPainted(true);
		progressBar.setBounds(10, 148, 414, 30);
		progressBar.setVisible(false);
		frame.getContentPane().add(progressBar);
		
		JLabel txtProgreso = new JLabel("...");
		txtProgreso.setForeground(Color.BLACK);
		txtProgreso.setBounds(10, 126, 171, 20);
		txtProgreso.setVisible(false);
		frame.getContentPane().add(txtProgreso);
		
	}
}
