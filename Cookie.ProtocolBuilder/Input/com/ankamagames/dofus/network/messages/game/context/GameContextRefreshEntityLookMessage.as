package com.ankamagames.dofus.network.messages.game.context
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameContextRefreshEntityLookMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5637;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:Number = 0;
      
      public var look:EntityLook;
      
      private var _looktree:FuncTree;
      
      public function GameContextRefreshEntityLookMessage()
      {
         this.look = new EntityLook();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5637;
      }
      
      public function initGameContextRefreshEntityLookMessage(param1:Number = 0, param2:EntityLook = null) : GameContextRefreshEntityLookMessage
      {
         this.id = param1;
         this.look = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = 0;
         this.look = new EntityLook();
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
         this.serializeAs_GameContextRefreshEntityLookMessage(param1);
      }
      
      public function serializeAs_GameContextRefreshEntityLookMessage(param1:ICustomDataOutput) : void
      {
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
         this.look.serializeAs_EntityLook(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameContextRefreshEntityLookMessage(param1);
      }
      
      public function deserializeAs_GameContextRefreshEntityLookMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this.look = new EntityLook();
         this.look.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameContextRefreshEntityLookMessage(param1);
      }
      
      public function deserializeAsyncAs_GameContextRefreshEntityLookMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         this._looktree = param1.addChild(this._looktreeFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of GameContextRefreshEntityLookMessage.id.");
         }
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
   }
}
