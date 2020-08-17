package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightTackledMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1004;
       
      
      private var _isInitialized:Boolean = false;
      
      public var tacklersIds:Vector.<Number>;
      
      private var _tacklersIdstree:FuncTree;
      
      public function GameActionFightTackledMessage()
      {
         this.tacklersIds = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1004;
      }
      
      public function initGameActionFightTackledMessage(param1:uint = 0, param2:Number = 0, param3:Vector.<Number> = null) : GameActionFightTackledMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.tacklersIds = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.tacklersIds = new Vector.<Number>();
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
         this.serializeAs_GameActionFightTackledMessage(param1);
      }
      
      public function serializeAs_GameActionFightTackledMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.tacklersIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.tacklersIds.length)
         {
            if(this.tacklersIds[_loc2_] < -9007199254740990 || this.tacklersIds[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.tacklersIds[_loc2_] + ") on element 1 (starting at 1) of tacklersIds.");
            }
            param1.writeDouble(this.tacklersIds[_loc2_]);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightTackledMessage(param1);
      }
      
      public function deserializeAs_GameActionFightTackledMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Number = NaN;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readDouble();
            if(_loc4_ < -9007199254740990 || _loc4_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of tacklersIds.");
            }
            this.tacklersIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightTackledMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightTackledMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._tacklersIdstree = param1.addChild(this._tacklersIdstreeFunc);
      }
      
      private function _tacklersIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._tacklersIdstree.addChild(this._tacklersIdsFunc);
            _loc3_++;
         }
      }
      
      private function _tacklersIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < -9007199254740990 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of tacklersIds.");
         }
         this.tacklersIds.push(_loc2_);
      }
   }
}
