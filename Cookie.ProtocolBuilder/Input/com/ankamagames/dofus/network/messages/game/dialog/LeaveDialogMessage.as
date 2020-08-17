package com.ankamagames.dofus.network.messages.game.dialog
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LeaveDialogMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5502;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dialogType:uint = 0;
      
      public function LeaveDialogMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5502;
      }
      
      public function initLeaveDialogMessage(param1:uint = 0) : LeaveDialogMessage
      {
         this.dialogType = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dialogType = 0;
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_LeaveDialogMessage(param1);
      }
      
      public function serializeAs_LeaveDialogMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.dialogType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LeaveDialogMessage(param1);
      }
      
      public function deserializeAs_LeaveDialogMessage(param1:ICustomDataInput) : void
      {
         this._dialogTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LeaveDialogMessage(param1);
      }
      
      public function deserializeAsyncAs_LeaveDialogMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dialogTypeFunc);
      }
      
      private function _dialogTypeFunc(param1:ICustomDataInput) : void
      {
         this.dialogType = param1.readByte();
         if(this.dialogType < 0)
         {
            throw new Error("Forbidden value (" + this.dialogType + ") on element of LeaveDialogMessage.dialogType.");
         }
      }
   }
}
