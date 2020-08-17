package com.ankamagames.dofus.network.messages.game.context.roleplay.lockable
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LockableShowCodeDialogMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5740;
       
      
      private var _isInitialized:Boolean = false;
      
      public var changeOrUse:Boolean = false;
      
      public var codeSize:uint = 0;
      
      public function LockableShowCodeDialogMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5740;
      }
      
      public function initLockableShowCodeDialogMessage(param1:Boolean = false, param2:uint = 0) : LockableShowCodeDialogMessage
      {
         this.changeOrUse = param1;
         this.codeSize = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.changeOrUse = false;
         this.codeSize = 0;
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
         this.serializeAs_LockableShowCodeDialogMessage(param1);
      }
      
      public function serializeAs_LockableShowCodeDialogMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.changeOrUse);
         if(this.codeSize < 0)
         {
            throw new Error("Forbidden value (" + this.codeSize + ") on element codeSize.");
         }
         param1.writeByte(this.codeSize);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LockableShowCodeDialogMessage(param1);
      }
      
      public function deserializeAs_LockableShowCodeDialogMessage(param1:ICustomDataInput) : void
      {
         this._changeOrUseFunc(param1);
         this._codeSizeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LockableShowCodeDialogMessage(param1);
      }
      
      public function deserializeAsyncAs_LockableShowCodeDialogMessage(param1:FuncTree) : void
      {
         param1.addChild(this._changeOrUseFunc);
         param1.addChild(this._codeSizeFunc);
      }
      
      private function _changeOrUseFunc(param1:ICustomDataInput) : void
      {
         this.changeOrUse = param1.readBoolean();
      }
      
      private function _codeSizeFunc(param1:ICustomDataInput) : void
      {
         this.codeSize = param1.readByte();
         if(this.codeSize < 0)
         {
            throw new Error("Forbidden value (" + this.codeSize + ") on element of LockableShowCodeDialogMessage.codeSize.");
         }
      }
   }
}
