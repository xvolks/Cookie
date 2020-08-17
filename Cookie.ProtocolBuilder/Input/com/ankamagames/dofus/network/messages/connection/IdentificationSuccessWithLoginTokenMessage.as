package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdentificationSuccessWithLoginTokenMessage extends IdentificationSuccessMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6209;
       
      
      private var _isInitialized:Boolean = false;
      
      public var loginToken:String = "";
      
      public function IdentificationSuccessWithLoginTokenMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6209;
      }
      
      public function initIdentificationSuccessWithLoginTokenMessage(param1:String = "", param2:String = "", param3:uint = 0, param4:uint = 0, param5:Boolean = false, param6:String = "", param7:Number = 0, param8:Number = 0, param9:Number = 0, param10:Boolean = false, param11:uint = 0, param12:String = "") : IdentificationSuccessWithLoginTokenMessage
      {
         super.initIdentificationSuccessMessage(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10,param11);
         this.loginToken = param12;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.loginToken = "";
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IdentificationSuccessWithLoginTokenMessage(param1);
      }
      
      public function serializeAs_IdentificationSuccessWithLoginTokenMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_IdentificationSuccessMessage(param1);
         param1.writeUTF(this.loginToken);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdentificationSuccessWithLoginTokenMessage(param1);
      }
      
      public function deserializeAs_IdentificationSuccessWithLoginTokenMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._loginTokenFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdentificationSuccessWithLoginTokenMessage(param1);
      }
      
      public function deserializeAsyncAs_IdentificationSuccessWithLoginTokenMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._loginTokenFunc);
      }
      
      private function _loginTokenFunc(param1:ICustomDataInput) : void
      {
         this.loginToken = param1.readUTF();
      }
   }
}
