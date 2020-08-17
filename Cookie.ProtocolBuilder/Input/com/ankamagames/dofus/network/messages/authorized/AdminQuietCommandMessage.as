package com.ankamagames.dofus.network.messages.authorized
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AdminQuietCommandMessage extends AdminCommandMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5662;
       
      
      private var _isInitialized:Boolean = false;
      
      public function AdminQuietCommandMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5662;
      }
      
      public function initAdminQuietCommandMessage(param1:String = "") : AdminQuietCommandMessage
      {
         super.initAdminCommandMessage(param1);
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
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
         this.serializeAs_AdminQuietCommandMessage(param1);
      }
      
      public function serializeAs_AdminQuietCommandMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AdminCommandMessage(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AdminQuietCommandMessage(param1);
      }
      
      public function deserializeAs_AdminQuietCommandMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AdminQuietCommandMessage(param1);
      }
      
      public function deserializeAsyncAs_AdminQuietCommandMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
      }
   }
}
