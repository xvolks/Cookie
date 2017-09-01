package com.ankamagames.dofus.network.messages.game.context.roleplay.emote
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class EmotePlayMassiveMessage extends EmotePlayAbstractMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5691;
       
      
      private var _isInitialized:Boolean = false;
      
      public var actorIds:Vector.<Number>;
      
      private var _actorIdstree:FuncTree;
      
      public function EmotePlayMassiveMessage()
      {
         this.actorIds = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5691;
      }
      
      public function initEmotePlayMassiveMessage(param1:uint = 0, param2:Number = 0, param3:Vector.<Number> = null) : EmotePlayMassiveMessage
      {
         super.initEmotePlayAbstractMessage(param1,param2);
         this.actorIds = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.actorIds = new Vector.<Number>();
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
         this.serializeAs_EmotePlayMassiveMessage(param1);
      }
      
      public function serializeAs_EmotePlayMassiveMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_EmotePlayAbstractMessage(param1);
         param1.writeShort(this.actorIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.actorIds.length)
         {
            if(this.actorIds[_loc2_] < -9007199254740990 || this.actorIds[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.actorIds[_loc2_] + ") on element 1 (starting at 1) of actorIds.");
            }
            param1.writeDouble(this.actorIds[_loc2_]);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EmotePlayMassiveMessage(param1);
      }
      
      public function deserializeAs_EmotePlayMassiveMessage(param1:ICustomDataInput) : void
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
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of actorIds.");
            }
            this.actorIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EmotePlayMassiveMessage(param1);
      }
      
      public function deserializeAsyncAs_EmotePlayMassiveMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._actorIdstree = param1.addChild(this._actorIdstreeFunc);
      }
      
      private function _actorIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._actorIdstree.addChild(this._actorIdsFunc);
            _loc3_++;
         }
      }
      
      private function _actorIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < -9007199254740990 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of actorIds.");
         }
         this.actorIds.push(_loc2_);
      }
   }
}
