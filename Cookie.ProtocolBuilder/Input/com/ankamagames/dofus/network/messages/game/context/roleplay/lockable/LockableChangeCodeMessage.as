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
   public class LockableChangeCodeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5666;
       
      
      private var _isInitialized:Boolean = false;
      
      public var code:String = "";
      
      public function LockableChangeCodeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5666;
      }
      
      public function initLockableChangeCodeMessage(param1:String = "") : LockableChangeCodeMessage
      {
         this.code = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.code = "";
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
         this.serializeAs_LockableChangeCodeMessage(param1);
      }
      
      public function serializeAs_LockableChangeCodeMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.code);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LockableChangeCodeMessage(param1);
      }
      
      public function deserializeAs_LockableChangeCodeMessage(param1:ICustomDataInput) : void
      {
         this._codeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LockableChangeCodeMessage(param1);
      }
      
      public function deserializeAsyncAs_LockableChangeCodeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._codeFunc);
      }
      
      private function _codeFunc(param1:ICustomDataInput) : void
      {
         this.code = param1.readUTF();
      }
   }
}
